using System.Collections.ObjectModel;
using TemperatureMonitoring.Model;

namespace TemperatureMonitoring
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TempHum> TempHumList { get; set; }
            = new ObservableCollection<TempHum>();

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private void LoadCsv_Clicked(object sender, EventArgs e)
        {
            var loader = new DataLoader();
            TempHumList.Clear();
            var appDirectory = System.AppContext.BaseDirectory;
            foreach (var item in loader.LoadCsv(Path.Combine(appDirectory,@"Data/data.csv")))
            {
                TempHumList.Add(item);
            }
        }
    }

}
