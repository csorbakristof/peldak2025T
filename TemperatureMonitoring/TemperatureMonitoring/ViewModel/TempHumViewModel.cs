using System.Collections.ObjectModel;
using TemperatureMonitoring.Model;

namespace TemperatureMonitoring.ViewModel
{
    public class TempHumViewModel
    {
        private RawTempHumContainer rawTempHumContainer;
        public TempHumViewModel(RawTempHumContainer model)
        {
            this.rawTempHumContainer = model;
            this.rawTempHumContainer.TempHumAddedEvent += UpdateStatistics;
        }

        public void AddToModel(IEnumerable<TempHum> newTempHums)
        {
            rawTempHumContainer.Add(newTempHums);
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
                TempHum200List.Add(item);
        }

        private const string ExternalTemperatureDeviceName = "T2_Terasz";
        private const string InternalTemperatureDeviceName = "T3_Kek";

        private void UpdateDailyMeanExternalInternalDifference()
        {
            var externalMeans = GetDailyMeans(rawTempHumContainer.AllTempHums
                .Where(th => th.DeviceName == ExternalTemperatureDeviceName));
            var internalMeans = GetDailyMeans(rawTempHumContainer.AllTempHums
                .Where(th => th.DeviceName == InternalTemperatureDeviceName));

            // Create a list with the difference between the external and internal means for every day separately.
            var dailyDifferences = externalMeans
                .Join(internalMeans,
                    e => e.Day,
                    i => i.Day,
                    (e, i) => new DailyValue
                    {
                        Day = e.Day,
                        Value = e.Value - i.Value
                    });

            DailyMeanExternalInternalDifference.Clear();
            foreach (var item in dailyDifferences)
                DailyMeanExternalInternalDifference.Add(item);
        }

        private IEnumerable<DailyValue> GetDailyMeans(IEnumerable<TempHum> tempHums)
        {
            return tempHums.GroupBy(th => th.Time.Date)
                .Select(g => new DailyValue {
                    Day = new DateOnly(g.Key.Year, g.Key.Month, g.Key.Day),
                    Value = g.Average(th => th.Temperature)
                });
        }

        public ObservableCollection<TempHum> TempHum200List { get; set; }
            = new ObservableCollection<TempHum>();

        public ObservableCollection<DailyValue> DailyMeanExternalInternalDifference { get; set; }
            = new ObservableCollection<DailyValue>();
    }
}
