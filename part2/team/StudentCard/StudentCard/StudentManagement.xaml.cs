using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using StudentCard.Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    /// StudentManagement.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StudentManagement : MetroWindow
    {
        public StudentManagement()
        {
            InitializeComponent();
        }

        public StudentManagement(int studentId, string studentName) : this()
        {
            studentId = Commons.STUDENTID;
            studentName = Commons.NAME;
        }

        private void BtnExitProgram_Click(object sender, RoutedEventArgs e)
        {
            MetroWindow_Closing(sender, new System.ComponentModel.CancelEventArgs());
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LblName.Content = Commons.NAME;
            LblStudentId.Content = Commons.STUDENTID;
            LblMajor.Content = Commons.Major;
        }

        private async void MetroWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

            var mySettings = new MetroDialogSettings
            {
                AffirmativeButtonText = "종료",
                NegativeButtonText = "취소",
                AnimateShow = true,
                AnimateHide = true
            };

            var result = await this.ShowMessageAsync("프로그램을 종료", "프로그램을 종료하시겠습니까?",
                                                     MessageDialogStyle.AffirmativeAndNegative, mySettings);

            if (result == MessageDialogResult.Negative)
            {
                e.Cancel = true;
            }
            else if (result == MessageDialogResult.Affirmative)
            {
                Process.GetCurrentProcess().Kill(); // 가장 확실한 끝내기 방법
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            MetroWindow_Closing(sender, new System.ComponentModel.CancelEventArgs());
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Owner.Show();
        }
    }
}
