using System.Collections.ObjectModel;
using TemperatureMonitoring.Model;

namespace TemperatureMonitoring.ViewModel
{
    public class TempHumViewModel
    {
        private RawTempHumContainer rawTempHumContainer;
        public TempHumViewModel(RawTempHumContainer rawTempHumContainer)
        {
            this.rawTempHumContainer = rawTempHumContainer;
            this.rawTempHumContainer.TempHumAddedEvent += UpdateStatistics;
        }

        public void AddToModel(IEnumerable<TempHum> newTempHums)
        {
            this.rawTempHumContainer.Add(newTempHums);
        }

        private void UpdateStatistics()
        {
            UpdateTempHum200();
            UpdateDailyMeanExternalInternalDifference();
        }

        private void UpdateTempHum200()
        {
            TempHum200List.Clear();
            foreach (var item in rawTempHumContainer.AllTempHums.Take(200))
            {
                this.TempHum200List.Add(item);
            }
        }

        const string ExternalTemperatureDeviceName = "T2_Terasz";
        const string InternalTemperatureDeviceName = "T3_Kek";

        private void UpdateDailyMeanExternalInternalDifference()
        {
            var externalMeans = GetDailyMeans(
                rawTempHumContainer.AllTempHums
                .Where(tempHum => tempHum.DeviceName == ExternalTemperatureDeviceName));
            var internalMeans = GetDailyMeans(
                rawTempHumContainer.AllTempHums
                .Where(tempHum => tempHum.DeviceName == InternalTemperatureDeviceName));

            // Create a list with the difference between the external and internal means for every day separately.
            var dailyMeanExternalInternalDifference = externalMeans
                .Join(internalMeans,
                    e => e.Day,
                    i => i.Day,
                    (e, i) => new DailyValue
                    {
                        Day = e.Day,
                        Value = e.Value - i.Value
                    });

            DailyMeanExternalInternalDifference.Clear();
            foreach(var item in dailyMeanExternalInternalDifference)
            {
                DailyMeanExternalInternalDifference.Add(item);
            }
        }

        private IEnumerable<DailyValue> GetDailyMeans(IEnumerable<TempHum> tempHums)
        {
            return tempHums
                .GroupBy(x => x.Time.Date)
                .Select(g => new DailyValue
                {
                    Day = new DateOnly(g.Key.Year, g.Key.Month, g.Key.Day),
                    Value = g.Average(x => x.Temperature)
                });
        }

        public ObservableCollection<TempHum> TempHum200List { get; set; }
            = new ObservableCollection<TempHum>();

        public ObservableCollection<DailyValue> DailyMeanExternalInternalDifference { get; set; }
            = new ObservableCollection<DailyValue>();

    }
}
