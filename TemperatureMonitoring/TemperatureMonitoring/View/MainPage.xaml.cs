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
            viewModel.TempHum200List.Clear();
            var appDirectory = System.AppContext.BaseDirectory;
            var tempHums = loader.LoadCsv(Path.Combine(appDirectory, @"Data/data.csv"));
            viewModel.AddToModel(tempHums);
        }

        private async void DownloadCsv_Clicked(object sender, EventArgs e)
        {
            var loader = new DataLoader();
            viewModel.TempHum200List.Clear();
            var downloadedTempHums = await loader.DownloadJson(@"http://localhost:5208/data");
            viewModel.AddToModel(downloadedTempHums);
        }
    }
}
