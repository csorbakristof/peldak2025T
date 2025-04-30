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
            foreach (var item in rawTempHumContainer.AllTempHums.Take(200))
            {
                this.TempHum200List.Add(item);
            }
        }

        public ObservableCollection<TempHum> TempHum200List { get; set; }
            = new ObservableCollection<TempHum>();
    }
}
