﻿using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using uPLibrary.Networking.M2Mqtt;

namespace SmartHomeMonitoringApp.Logics
{
    public class Commons
    {
        // 화면마다 공유할 MQTT 브로커 ip 변수
        public static string BROKERHOST { get; set; } = "210.119.12.68";

        public static string MQTTTOPIC { get; set; } = "pknu/rpi/control/";

        public static string MYSQL_CONNSTRING { get; set; } = "Server=localhost;" +
                                                              "Port=3306;" +
                                                              "Database=miniproject;" +
                                                              "Uid=root;" +
                                                              "Pwd=12345;";
        // MQTT 클라이언트 공용 객체
        public static MqttClient MQTT_CLIENT { get; set; }

        // UserControl 같이 자식 클래스면서 MetroWindow를 직접 사용하지 않아, MahApp.Metro에 있는 Metro 메시지창을 못쓸 때
        public static async Task<MessageDialogResult> ShowCustomMessageAsync(string title, string message,
            MessageDialogStyle style = MessageDialogStyle.Affirmative)
        {
            return await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync(title, message, style, null);
        }
    }
}
