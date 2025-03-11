using OxyPlot.Series;
using OxyPlot;

namespace TemperatureMonitoring.View;

public partial class StatisticsPage : ContentPage
{
	public StatisticsPage()
	{
		InitializeComponent();
		this.BindingContext = this;


        var dataPoints = Enumerable.Range(1, 10).Select(x => new DataPoint(x, x * 10));
        var model = new PlotModel();
        model.Title = "Sample Test";
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