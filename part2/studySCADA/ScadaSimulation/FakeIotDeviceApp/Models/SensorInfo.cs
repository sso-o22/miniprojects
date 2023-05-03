using System;

namespace FakeIotDeviceApp.Models
{
    public class SensorInfo
    {
        public string Home_Id { get; set; }  // 101동 - 101호~104호, 201호~204호 => ex) D101H101 D101H102
        public string Room_Name { get; set; }  // Living, Dining, Bed, Bath
        public DateTime Sensing_DateTime { get; set; }  // 센싱되는 현재시각
        public float Temp { get ; set; }  // 온도
        public float Humid { get; set; }  // 습도
    }
}
