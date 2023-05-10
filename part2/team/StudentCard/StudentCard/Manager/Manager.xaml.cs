using MahApps.Metro.Controls;
using StudentCard.Logics;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace StudentCard
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Manager : MetroWindow
    {
        public Manager()
        {
            InitializeComponent();

            Lbl_RoomTem1.Content = Lbl_RoomTem2.Content = Lbl_RoomTem3.Content = 0;
            Lbl_RoomHum1.Content = Lbl_RoomHum2.Content = Lbl_RoomHum3.Content = 0;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (MqttReceive.MQTT_CLIENT != null && MqttReceive.MQTT_CLIENT.IsConnected)
            {   // DB 모니터링을 실행한 뒤 실시간 모니터링으로 넘어왔다면
                MqttReceive.MQTT_CLIENT.MqttMsgPublishReceived += MQTT_CLIENT_MqttMsgPublishReceived;

            }
            else
            {   // DB 모니터링은 실행하지 않고 바로 실시간 모니터링 메뉴를 클릭한 경우
                MqttReceive.MQTT_CLIENT = new MqttClient(MqttReceive.BROKERHOST);
                MqttReceive.MQTT_CLIENT.MqttMsgPublishReceived += MQTT_CLIENT_MqttMsgPublishReceived;
                MqttReceive.MQTT_CLIENT.Connect("MONITOR");
                MqttReceive.MQTT_CLIENT.Subscribe(new string[] { MqttReceive.MQTTTOPIC },
                    new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            }
        }


        private void MQTT_CLIENT_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            var msg = Encoding.UTF8.GetString(e.Message);
            Debug.WriteLine(msg);
            var currSensor = JsonConvert.DeserializeObject<Dictionary<string, string>>(msg);

            if (currSensor["Home_Id"] != null)    // D101H703은 사용자 DB에서 동적으로 가져와할 값
            {
                this.Invoke(() =>
                {
                    var dfValue = DateTime.Parse(currSensor["Sensing_DateTime"]).ToString("yyyy-MM-dd : HH-mm-ss");
                    Lbl_SensingDt.Content = $"Sensing DateTime : {currSensor["Sensing_DateTime"]}";
                });

                switch (currSensor["Home_Id"].ToUpper())
                {
                    case "101":
                        this.Invoke(() =>
                        {
                            Lbl_RoomTem1.Content = Math.Round(Convert.ToDouble(currSensor["Temp"]), 1);
                            Lbl_RoomHum1.Content = Convert.ToDouble(currSensor["Humid"]);
                        });
                        break;

                    case "102":
                        this.Invoke(() =>
                        {
                            Lbl_RoomTem2.Content = Math.Round(Convert.ToDouble(currSensor["Temp"]), 1);
                            Lbl_RoomHum2.Content = Convert.ToDouble(currSensor["Humid"]);
                        });
                        break;

                    case "103":
                        this.Invoke(() =>
                        {
                            Lbl_RoomTem3.Content = Math.Round(Convert.ToDouble(currSensor["Temp"]), 1);
                            Lbl_RoomHum3.Content = Convert.ToDouble(currSensor["Humid"]);
                        });
                        break;
                    default:
                        break;
                }
                avg();
            }
        }

        private void avg()
        {
            this.Invoke(() =>
            {
                Lbl_avg_Tem.Content = (Convert.ToInt32(Lbl_RoomTem1.Content) + Convert.ToInt32(Lbl_RoomTem2.Content) + Convert.ToInt32(Lbl_RoomTem3.Content)) / 2;
                Lbl_avg_Hum.Content = (Convert.ToInt32(Lbl_RoomHum1.Content) + Convert.ToInt32(Lbl_RoomHum2.Content) + Convert.ToInt32(Lbl_RoomTem3.Content)) / 2;
            });
        }

        private void MetroWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            /*            double width = e.NewSize.Width;
                        Debug.WriteLine(width);
                        // 그리드의 ColumnDefinitions 수를 조절하는 코드
                        int newColumnCount = (int)Math.Floor(e.NewSize.Width / 200);
                        if (newColumnCount < 1)
                        {
                            newColumnCount = 1;
                        }
                        Lbl.Content = newColumnCount;*/
        }

        private void Btn_Fire_Click(object sender, RoutedEventArgs e)
        {
            Lbl_fire.Content = $"{Lbl_RoomNum1.Content} 호실에 불이야!!!!";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Student_List dataMiner = new Student_List();
            dataMiner.Show();
        }

        private void MenuItem_FakeData(object sender, RoutedEventArgs e)
        {
            FakeData fakeData = new FakeData();
            fakeData.Show();
        }

        private void Btn_SaveData_Click(object sender, RoutedEventArgs e)
        {
            var msg = "";
            SaveData();        // 실제 DB에 저장처리
        }

        private async void SaveData()
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(MqttReceive.MYSQL_CONNSTRING))
                {
                    if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                    string insQuery = @"INSERT INTO campusdb.averagetbl
                                                (department,
                                                date,
                                                avg_temp,
                                                avg_humi)
                                                VALUES
                                                (@department,
                                                @date,
                                                @avg_temp,
                                                @avg_humi)";

                    MySqlCommand cmd = new MySqlCommand(insQuery, conn);
                    cmd.Parameters.AddWithValue("@department", "1");
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@avg_temp", Lbl_avg_Tem.Content);
                    cmd.Parameters.AddWithValue("@avg_humi", Lbl_avg_Hum.Content);
                    int affectedRows = await cmd.ExecuteNonQueryAsync(); // INSERT 쿼리 실행

                    await Commons.ShowMessageAsync("저장", "DB저장 성공!!");

                }
            }
            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", ex.Message);
            }



        }




    }
}
