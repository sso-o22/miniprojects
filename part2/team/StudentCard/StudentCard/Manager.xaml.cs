using MahApps.Metro.Controls;
using System;
using System.Diagnostics;
using System.Windows;

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

                        if (dataGrid.ColumnDefinitions.Count != newColumnCount)
                        {
                            dataGrid.ColumnDefinitions.Clear();
                            for (int i = 0; i < newColumnCount; i++)
                            {
                                dataGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                            }
                        }


                        int newRowcount = (int)Math.Floor(e.NewSize.Height / 200);
                        if (newRowcount < 1)
                        {
                            newRowcount = 1;
                        }

                        if (dataGrid.RowDefinitions.Count != newRowcount)
                        {
                            dataGrid.RowDefinitions.Clear();
                            for (int i = 0; i < newRowcount; i++)
                            {
                                dataGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                            }
                        }



                        // 새로운 라벨을 추가하는 코드
                        dataGrid.Children.Clear();
                        for (int i = 0; i < newColumnCount; i++)
                        {
                            Label label = new Label();
                            label.Content = $"Label {i + 1}";
                            label.HorizontalAlignment = HorizontalAlignment.Center;
                            label.VerticalAlignment = VerticalAlignment.Center;
                            Grid.SetColumn(label, i);
                            dataGrid.Children.Add(label);


                        }*/
            double width = e.NewSize.Width;
            Debug.WriteLine(width);
            // 그리드의 ColumnDefinitions 수를 조절하는 코드
            int newColumnCount = (int)Math.Floor(e.NewSize.Width / 200);
            if (newColumnCount < 1)
            {
                newColumnCount = 1;
            }
            Lbl.Content = newColumnCount;

        }


        private void Btn_Room1_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            float randomNum = random.Next(101, 110);
            float randomTmp = random.Next(1, 41);
            float randomHum = random.Next(1, 80);

            Lbl_RoomNum1.Content = randomNum;
            Lbl_RoomTem1.Content = randomTmp;
            Lbl_RoomHum1.Content = randomHum;

            avgTemp();
        }

        private void Btn_Room2_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            float randomNum = random.Next(101, 110);
            float randomTmp = random.Next(1, 41);
            float randomHum = random.Next(1, 80);

            Lbl_RoomNum2.Content = randomNum;
            Lbl_RoomTem2.Content = randomTmp;
            Lbl_RoomHum2.Content = randomHum;

            avgTemp();
        }

        private void avgTemp()
        {
            float avgTem = (Convert.ToInt32(Lbl_RoomTem1.Content) + Convert.ToInt32(Lbl_RoomTem2.Content) + Convert.ToInt32(Lbl_RoomTem3.Content)) / 2;
            float avgHum = (Convert.ToInt32(Lbl_RoomHum1.Content) + Convert.ToInt32(Lbl_RoomHum2.Content) + Convert.ToInt32(Lbl_RoomTem3.Content)) / 2;

            Lbl_avg_Tem.Content = avgTem;
            Lbl_avg_Hum.Content = avgHum;
        }

        private void Btn_Fire_Click(object sender, RoutedEventArgs e)
        {
            Lbl_fire.Content = $"{Lbl_RoomNum1.Content} 호실에 불이야!!!!";
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Room3_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            float randomNum = random.Next(101, 110);
            float randomTmp = random.Next(1, 41);
            float randomHum = random.Next(1, 80);

            Lbl_RoomNum3.Content = randomNum;
            Lbl_RoomTem3.Content = randomTmp;
            Lbl_RoomHum3.Content = randomHum;

            avgTemp();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Student_List dataMiner = new Student_List();
            dataMiner.Show();
        }
    }
}
