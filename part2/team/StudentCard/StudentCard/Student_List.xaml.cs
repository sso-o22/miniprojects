using MahApps.Metro.Controls;
using StudentCard.Logics;
using StudentCard.Module;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace StudentCard
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Student_List : MetroWindow
    {

        public string selItem;
        public string target;


        public Student_List()
        {
            InitializeComponent();
        }

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TbxSearch.Text;
                switch (selItem)
                {
                    case "0":   // 학번
                        target = $"WHERE studentID LIKE '%{text}%'";
                        break;
                    case "1":   // 이름
                        target = $"WHERE studentName LIKE '%{text}%'"; ;
                        break;
                    default:
                        target = $"WHERE studentID LIKE '%{text}%'";
                        break;
                }
                using (MySqlConnection conn = new MySqlConnection(Commons.myConnString))
                {
                    conn.Open();
                    var query = @"SELECT studentID,
                            studentName,
                            birthday,
                            major,
                            PhoneNum,
                            address,
                            gender
                            FROM studenttbl " + target;
                    Debug.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "List");
                    List<StudentList> strings = new List<StudentList>();
                    foreach (DataRow row in ds.Tables["List"].Rows)
                    {
                        strings.Add(new StudentList
                        {
                            studentID = Convert.ToInt32(row["studentID"]),
                            studentName = Convert.ToString(row["studentName"]),
                            birthday = Convert.ToString(row["birthday"]),
                            major = Convert.ToString(row["major"]),
                            address = Convert.ToString(row["address"]),
                            gender = Convert.ToString(row["gender"]),
                        });
                    }

                    this.DataContext = strings;
                }
            }
            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", $"DB 저장오류 {ex.Message}");

            }
        }

        //private void BtnReference_Click(object sender, RoutedEventArgs e)
        //{
        //    using (MySqlConnection conn = new MySqlConnection(Commons.myConnstring))
        //    {
        //        conn.Open();
        //        var query = @"SELECT studentID,
        //                    studentName,
        //                    birthday,
        //                    major,
        //                    PhoneNum,
        //                    address,
        //                    gender
        //                    FROM studenttbl";
        //        MySqlCommand cmd = new MySqlCommand(query, conn);
        //        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        adapter.Fill(ds, "List");
        //        List<StudentList> strings = new List<StudentList>();
        //        foreach (DataRow row in ds.Tables["List"].Rows)
        //        {
        //            strings.Add(new StudentList
        //            {
        //                studentID = Convert.ToInt32(row["studentID"]),
        //                studentName = Convert.ToString(row["studentName"]),
        //                birthday = Convert.ToString(row["birthday"]),
        //                major = Convert.ToString(row["major"]),
        //                address = Convert.ToString(row["address"]),
        //                gender = Convert.ToString(row["gender"]),
        //            });
        //        }

        //        this.DataContext = strings;
        //    }
        //}

        private void CboDivision_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selItem = Convert.ToString(CboDivision.SelectedIndex);
            //using (MySqlConnection conn = new MySqlConnection(Commons.myConnstring))
            //{
            //conn.Open();
            //var query = @"SELECT studentID AS ,
            //            studentName 

            //            FROM studenttbl
            //            GROUP BY 1
            //            ORDER BY 1";
            //MySqlCommand cmd = new MySqlCommand(query, conn);
            //MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds);
            //List<string> saveDateList = new List<string>();
            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    saveDateList.Add(Convert.ToString(row["Save_Date"]));
            //}

            //Cboplace_nm.ItemsSource = saveDateList;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CboDivision.SelectedIndex = 0;
        }
    }
}
