using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            TempHum200List.Clear();
            foreach(var item in rawTempHumContainer.AllTempHums.Take(200))
            {
                TempHum200List.Add(item);
            }
        }

        public ObservableCollection<TempHum> TempHum200List { get; set; }
            = new ObservableCollection<TempHum>();
    }
}
