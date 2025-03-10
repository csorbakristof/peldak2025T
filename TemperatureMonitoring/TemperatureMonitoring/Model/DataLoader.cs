using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitoring.Model
{
    public class DataLoader
    {
        public IEnumerable<TempHum> LoadCsv(string filename)
        {
            var lines = System.IO.File.ReadAllLines(filename);
            string deviceName = lines[0];
            for (int i = 2; i < lines.Length; i++)
            {
                var fields = lines[i].Split(';');
                var timestamp = long.Parse(fields[0]);
                yield return new TempHum
                {
                    DeviceName = deviceName,
                    TimeStamp = timestamp,
                    Temperature = double.Parse(fields[1]),
                    Humidity = double.Parse(fields[2]),
                    Time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp)
                };
            }
        }
    }
}
