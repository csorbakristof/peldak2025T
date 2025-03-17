namespace TemperatureMonitoring
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            var vm = new ViewModel.TempHumViewModel();
            var mainPage = new MainPage(vm);

            var flyoutItemMainPage = new FlyoutItem() { Title="Temperature monitoring" };
            flyoutItemMainPage.Items.Add( new ShellContent() { Content = mainPage });
            flyoutItemMainPage.Icon = new FileImageSource() { File = @"home.png" };

            Items.Add(flyoutItemMainPage);
        }
    }
}
