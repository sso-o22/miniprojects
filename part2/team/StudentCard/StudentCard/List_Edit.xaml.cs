using MahApps.Metro.Controls;
using StudentCard.Logics;
using StudentCard.Module;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace StudentCard
{
    /// <summary>
    /// List_Edit.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class List_Edit : MetroWindow
    {
        public List_Edit()
        {
            InitializeComponent();
        }
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //using(MySqlConnection conn = new MySqlConnection(Commons.myConnstring))
            //{
            //    if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
            //    var query = @
            //}



        }

        bool isExist = false;
        // 편집 버튼
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        // 삭제 버튼
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CboMajor_Selected(object sender, RoutedEventArgs e)
        {
            //using (MySqlConnection conn = new MySqlConnection(Commons.myConnstring))
            //{
            //    conn.Open();
            //    var query = @"SELECT majorId,
            //                            name
            //                        FROM major
            //                        WHERE name=@name";

            //    MySqlCommand cmd = new MySqlCommand(query, conn);
            //    cmd.Parameters.AddWithValue("@name", CboMajor.SelectedValue.ToString());

            //}

        }
    }
}
