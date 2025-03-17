using OxyPlot;
using OxyPlot.Series;
using TemperatureMonitoring.ViewModel;

namespace TemperatureMonitoring.View;

public partial class StatisticsPage : ContentPage
{
    private TempHumViewModel viewModel;

    public StatisticsPage(TempHumViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
		this.viewModel = vm;
        vm.TempHumList.CollectionChanged += TempHumList_CollectionChanged;
    }

    private void TempHumList_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        var dataPoints = this.viewModel.TempHumList.Select((tempHum,index) => new DataPoint(index, tempHum.Temperature)).ToList();
        var model = new PlotModel { Title = "Temperature" };
        model.Series.Add(new LineSeries {
            ItemsSource = dataPoints,
            Color = OxyColors.Blue,
            MarkerType = MarkerType.Circle,
        });
        PlotView.Model = model;
        model.InvalidatePlot(true);
    }
}