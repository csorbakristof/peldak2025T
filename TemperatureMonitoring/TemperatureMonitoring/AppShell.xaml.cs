using TemperatureMonitoring.View;

namespace TemperatureMonitoring
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            var vm = new ViewModel.TempHumViewModel(new Model.RawTempHumContainer());
            var mainPage = new MainPage(vm);
            var statisticsPage = new StatisticsPage(vm);

            var flyoutItemMainPage = new FlyoutItem() { Title = "Temperature monitoring" };
            flyoutItemMainPage.Items.Add(new ShellContent() { Content = mainPage });
            flyoutItemMainPage.Icon = new FileImageSource() { File = @"home.png" };

            var flyoutItemStatisticsPage = new FlyoutItem() { Title = "Statistics" };
            flyoutItemStatisticsPage.Items.Add(new ShellContent() { Content = statisticsPage });
            flyoutItemStatisticsPage.Icon = new FileImageSource() { File = @"statistics.png" };

            Items.Add(flyoutItemMainPage);
            Items.Add(flyoutItemStatisticsPage);
        }
    }
}
