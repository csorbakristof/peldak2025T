namespace TemperatureMonitoring.Model
{
    public class TempHum
    {
        public required string DeviceName { get; set; }
        public long TimeStamp { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime Time { get; set; }
    }
}
