using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.Specialized;
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
        vm.TempHum200List.CollectionChanged += TempHum200List_CollectionChanged;
        vm.DailyMeanExternalInternalDifference.CollectionChanged += DailyMeanExternalInternalDifference_CollectionChanged;
    }

    private void TempHum200List_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        var dataPoints = this.viewModel.TempHum200List.Select((tempHum,index) => new DataPoint(index, tempHum.Temperature)).ToList();
        var model = new PlotModel { Title = "Temperature" };
        model.Series.Add(new LineSeries {
            ItemsSource = dataPoints,
            Color = OxyColors.Blue,
            MarkerType = MarkerType.Circle,
        });
        PlotViewTH200.Model = model;
        model.InvalidatePlot(true);
    }

    private void DailyMeanExternalInternalDifference_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        var dataPoints = this.viewModel.DailyMeanExternalInternalDifference.Select(diff => new DataPoint(
            DateTimeAxis.ToDouble(diff.Day.ToDateTime(new TimeOnly())),
            diff.Value
            )).ToList();
        var model = new PlotModel { Title = "Daily temperature diff" };
        model.Axes.Add(new DateTimeAxis
        {
            Position = AxisPosition.Bottom,
            MajorGridlineStyle = LineStyle.Solid,
            MajorStep = 30,
            IsZoomEnabled = true,
            StringFormat = "MMM dd"
        });
        model.Series.Add(new LineSeries
        {
            ItemsSource = dataPoints,
            Color = OxyColors.Blue,
            MarkerType = MarkerType.Circle,
        });
        PlotViewDailyDiff.Model = model;
        model.InvalidatePlot(true);
    }
}
