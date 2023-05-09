using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentCard.Logics;
using StudentCard.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace StudentCard
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WhyPark_Manager : MetroWindow
    {
        // bool isFavorite = false;
        public WhyPark_Manager()
        {
            InitializeComponent();
        }

        private async void BtnReqRealtime_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = null;
            // TxtMovieName.DataContext = string.Empty;

            List<WhyParkStudent> list = new List<WhyParkStudent>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.myConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"SELECT studentID,
                                        studentName,
                                        reason,
                                        startDate,
                                        endDate
                                    FROM managertbl";

                    var cmd = new MySqlCommand(query, conn);
                    var adapter = new MySqlDataAdapter(cmd);
                    var dSet = new DataSet();
                    adapter.Fill(dSet, "GrdResult");

                    foreach (DataRow dr in dSet.Tables["GrdResult"].Rows)
                    {
                        list.Add(new WhyParkStudent
                        {
                            StudentID = Convert.ToInt32(dr["studentID"]),
                            StudentName = Convert.ToString(dr["studentName"]),
                            Reason = Convert.ToString(dr["reason"]),
                            StartDate = Convert.ToDateTime(dr["startDate"]),
                            EndDate = Convert.ToDateTime(dr["endDate"])
                        });
                    }

                    this.DataContext = list;
                    // isFavorite = true;
                    StsResult.Content = $"{list.Count}건 조회완료";

                }

            }
            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", $"DB조회 오류 {ex.Message}");
            }
        }


        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSearch.Text))
            {
                await Commons.ShowMessageAsync("검색", "검색할 학생명을 입력하세요.");
                return;
            }
            try
            {
                SearchName(TxtSearch.Text);
            }
            catch (Exception ex)
            {

                await Commons.ShowMessageAsync("오류", $"오류발생 : {ex.Message}");
            }
        }

        private async void SearchName(string text)
        {
            this.DataContext = null;
            // TxtMovieName.DataContext = string.Empty;

            List<WhyParkStudent> list = new List<WhyParkStudent>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.myConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = $@"SELECT studentID,
                                        studentName,
                                        reason,
                                        startDate,
                                        endDate
                                    FROM managertbl
                                    WHERE studentName LIKE '%{TxtSearch.Text}%'";


                    var cmd = new MySqlCommand(query, conn);
                    var adapter = new MySqlDataAdapter(cmd);
                    var dSet = new DataSet();
                    adapter.Fill(dSet, "GrdResult");

                    foreach (DataRow dr in dSet.Tables["GrdResult"].Rows)
                    {
                        list.Add(new WhyParkStudent
                        {
                            StudentID = Convert.ToInt32(dr["studentID"]),
                            StudentName = Convert.ToString(dr["studentName"]),
                            Reason = Convert.ToString(dr["reason"]),
                            StartDate = Convert.ToDateTime(dr["startDate"]),
                            EndDate = Convert.ToDateTime(dr["endDate"])
                        });
                    }

                    this.DataContext = list;
                    // isFavorite = true;
                    StsResult.Content = $"{list.Count}건 조회완료";

                }

            }
            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", $"DB조회 오류 {ex.Message}");
            }
        }

        private void TxtSearchStudent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnSearch_Click(sender, e);
            }
        }

        private async void BtnSearchDate_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = null;
            // TxtMovieName.DataContext = string.Empty;

            DateTime? selectedstartDate = DTPstartdate.SelectedDateTime;
            if (selectedstartDate.HasValue)
            {
                string startdateString = selectedstartDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                // 선택한 날짜와 시간을 "yyyy-MM-dd HH:mm:ss" 형식의 문자열로 변환하여 dateString 변수에 저장
            }
            else
            {
                await Commons.ShowMessageAsync("오류", $"개같은 오류");
            }

            DateTime? selectedendDate = DTPenddate.SelectedDateTime;
            if (selectedendDate.HasValue)
            {
                string startdateString = selectedendDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                // 선택한 날짜와 시간을 "yyyy-MM-dd HH:mm:ss" 형식의 문자열로 변환하여 dateString 변수에 저장
            }
            else
            {
                await Commons.ShowMessageAsync("오류", $"개같은 오류");
            }

            List<WhyParkStudent> list = new List<WhyParkStudent>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.myConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = $@"SELECT studentID,
                                        studentName,
                                        reason,
                                        startDate,
                                        endDate
                                    FROM managertbl
                                    WHERE  {selectedstartDate}>= startdate;
 ";


                    var cmd = new MySqlCommand(query, conn);
                    var adapter = new MySqlDataAdapter(cmd);
                    var dSet = new DataSet();
                    adapter.Fill(dSet, "GrdResult");

                    foreach (DataRow dr in dSet.Tables["GrdResult"].Rows)
                    {
                        list.Add(new WhyParkStudent
                        {
                            StudentID = Convert.ToInt32(dr["studentID"]),
                            StudentName = Convert.ToString(dr["studentName"]),
                            Reason = Convert.ToString(dr["reason"]),
                            StartDate = Convert.ToDateTime(dr["startDate"]),
                            EndDate = Convert.ToDateTime(dr["endDate"])
                        });
                    }

                    this.DataContext = list;
                    // isFavorite = true;
                    StsResult.Content = $"{list.Count}건 조회완료";

                }

            }
            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", $"DB조회 오류 {ex.Message}");
            }
        }

        //private void CboReqDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (CboReqDate.SelectedValue != null)
        //    {
        //        // MessageBox.Show(CboReqDate.SelectedValue.ToString());
        //        using (MySqlConnection conn = new MySqlConnection(Commons.myConnString))
        //        {
        //            conn.Open();
        //            var query = @"SELECT studentID,
        //                                studentName,
        //                                reason,
        //                                startDate,
        //                                endDate
        //                            FROM managertbl
        //                            WHERE DATE_FORMAT(startDate, '%Y-%m-%d') = @Timestamp ";

        //            MySqlCommand cmd = new MySqlCommand(query, conn);
        //            cmd.Parameters.AddWithValue("@Timestamp", CboReqDate.SelectedValue.ToString());
        //            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
        //            DataSet ds = new DataSet();
        //            adapter.Fill(ds, "dustsensor");
        //            List<DustSensor> dustSensors = new List<DustSensor>();

        //            foreach (DataRow row in ds.Tables["dustsensor"].Rows)
        //            {
        //                dustSensors.Add(new DustSensor
        //                {
        //                    Id = Convert.ToInt32(row["Id"]),    // mySql은 컬럼이름에 대소문자 구분없이 쓰기때문에
        //                    Dev_id = Convert.ToString(row["Dev_id"]),
        //                    Name = Convert.ToString(row["Name"]),
        //                    Loc = Convert.ToString(row["Loc"]),
        //                    Coordx = Convert.ToDouble(row["Coordx"]),
        //                    Coordy = Convert.ToDouble(row["Coordy"]),
        //                    Ison = Convert.ToBoolean(row["Ison"]),
        //                    Pm10_after = Convert.ToInt32(row["Pm10_after"]),
        //                    Pm25_after = Convert.ToInt32(row["Pm25_after"]),
        //                    State = Convert.ToInt32(row["State"]),
        //                    Timestamp = Convert.ToDateTime(row["Timestamp"]),
        //                    Company_id = Convert.ToString(row["Company_id"]),
        //                    Company_name = Convert.ToString(row["Company_name"])
        //                });
        //            }

        //            this.DataContext = dustSensors;
        //            StsResult.Content = $"DB {dustSensors.Count} 건 조회완료";
        //        }
        //    }
    }
}

