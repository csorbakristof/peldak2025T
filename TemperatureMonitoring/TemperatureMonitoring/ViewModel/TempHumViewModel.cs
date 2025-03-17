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
        public ObservableCollection<TempHum> TempHumList { get; set; }
            = new ObservableCollection<TempHum>();
    }
}
