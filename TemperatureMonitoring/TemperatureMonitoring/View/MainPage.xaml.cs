using System.Collections.ObjectModel;
using TemperatureMonitoring.Model;
using TemperatureMonitoring.ViewModel;

namespace TemperatureMonitoring.View
{
    public partial class MainPage : ContentPage
    {
        private TempHumViewModel viewModel;

        public MainPage(TempHumViewModel vm)
        {
            InitializeComponent();
            this.viewModel = vm;
            this.BindingContext = vm;
        }

        private void LoadCsv_Clicked(object sender, EventArgs e)
        {
            var loader = new DataLoader();
            viewModel.TempHumList.Clear();
            var appDirectory = System.AppContext.BaseDirectory;
            foreach (var item in loader.LoadCsv(Path.Combine(appDirectory,@"Data/data.csv")).Take(200))
            {
                viewModel.TempHumList.Add(item);
            }
        }

        private async void DownloadCsv_Clicked(object sender, EventArgs e)
        {
            var loader = new DataLoader();
            viewModel.TempHumList.Clear();
            var appDirectory = System.AppContext.BaseDirectory;
            var downloadedTempHums = await loader.DownloadCsv(@"http://localhost:5244/data");
            foreach (var item in downloadedTempHums.Take(200))
            {
                viewModel.TempHumList.Add(item);
            }
        }
    }

}
