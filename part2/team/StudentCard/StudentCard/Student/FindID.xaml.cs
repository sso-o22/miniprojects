using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MySql.Data.MySqlClient;
using StudentCard.Logics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    /// FindID.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindID : MetroWindow
    {
        public FindID()
        {
            InitializeComponent();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Owner.Show();
        }

        private async void BtnFindId_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtName.Text) || string.IsNullOrEmpty(TxtBirthday.Text) || string.IsNullOrEmpty(TxtPhoneNum.Text))
            {
                var mySettings = new MetroDialogSettings
                {
                    AffirmativeButtonText = "확인",
                    NegativeButtonText = "취소",
                    AnimateShow = true,
                    AnimateHide = true
                };

                var result = await this.ShowMessageAsync("주의", "정보를 입력하세요",
                                                         MessageDialogStyle.AffirmativeAndNegative, mySettings);
            }
            else
            {
                
            }
        }

        private async void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            var mySettings = new MetroDialogSettings
            {
                AffirmativeButtonText = "종료",
                NegativeButtonText = "취소",
                AnimateShow = true,
                AnimateHide = true
            };

            var result = await this.ShowMessageAsync("프로그램 종료", "프로그램을 종료하시겠습니까?",
                                                     MessageDialogStyle.AffirmativeAndNegative, mySettings);

            if (result == MessageDialogResult.Negative)
            {
                e.Cancel = true;
            }
            else if (result == MessageDialogResult.Affirmative)
            {
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}

