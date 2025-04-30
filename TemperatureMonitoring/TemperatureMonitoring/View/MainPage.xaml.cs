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

        private void LoadMergedJson_Clicked(object sender, EventArgs e)
        {
            var loader = new DataLoader();
            var appDirectory = System.AppContext.BaseDirectory;
            var tempHums = loader.LoadMergedJson(Path.Combine(appDirectory, @"Data/allTempLog.json"));
            viewModel.AddToModel(tempHums);
        }
    }
}
