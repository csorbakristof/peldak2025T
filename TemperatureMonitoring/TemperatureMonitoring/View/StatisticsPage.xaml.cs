using OxyPlot.Series;
using OxyPlot;
using TemperatureMonitoring.ViewModel;
using System.Collections.Specialized;

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

    private void TempHumList_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        var dataPoints = this.viewModel.TempHumList.Select((item, index) => new DataPoint(index, item.Temperature)).ToList();
        var model = new PlotModel();
        model.Title = "Temperatures";
        model.Series.Add(new LineSeries
        {
            ItemsSource = dataPoints,
            Color = OxyColors.Blue,
            MarkerType = MarkerType.Square,
        });
        PlotView.Model = model;
        model.InvalidatePlot(true);
    }
}