using System.Globalization;
using System.Text.Json;

namespace TemperatureMonitoring.Model
{
    public class DataLoader
    {
        public IEnumerable<TempHum> LoadMergedJson(string filename)
        {
            var json = File.ReadAllText(filename);
            var tempHumData = JsonSerializer.Deserialize<IEnumerable<TempHum>>(json,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return tempHumData ?? Enumerable.Empty<TempHum>();
        }
    }
}
