using Microsoft.UI.Xaml.Controls;
using TemperatureMonitoring.View;

namespace TemperatureMonitoring
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            var vm = new ViewModel.TempHumViewModel();

            var mainPage = new MainPage(vm);
            var statisticsPage = new StatisticsPage(vm);
            
            var flyoutMainPage = new FlyoutItem { Title = "Temperature Monitoring" };
            flyoutMainPage.Items.Add(new ShellContent { Content = mainPage });
            flyoutMainPage.Icon = new FileImageSource() { File = @"home.png" };
            var flyoutStatisticsPage = new FlyoutItem { Title = "Statistics" };
            flyoutStatisticsPage.Items.Add(new ShellContent { Content = statisticsPage });
            flyoutStatisticsPage.Icon = new FileImageSource() { File = @"statistics.png" };
            Items.Add(flyoutMainPage);
            Items.Add(flyoutStatisticsPage);
        }
    }
}
