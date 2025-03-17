using System.Collections.ObjectModel;
using TemperatureMonitoring.Model;

namespace TemperatureMonitoring.View
{
    public partial class MainPage : ContentPage
    {
        private TemperatureMonitoring.ViewModel.TempHumViewModel viewModel;

        public MainPage(ViewModel.TempHumViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
            this.viewModel = viewModel;
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
            var downloadedTempHums = await loader.DownloadCsv(@"http://localhost:5208/data");
            foreach (var item in downloadedTempHums.Take(200))
            {
                viewModel.TempHumList.Add(item);
            }
        }
    }
}
