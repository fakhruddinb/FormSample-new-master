using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FormSample
{
	using OxyPlot;
	using OxyPlot.Axes;
	using OxyPlot.Series;

	using Xamarin.Forms;

	public class ColumnChartPage : ContentPage
	{

		public ColumnChartPage()
		{
			// var layout= GenerateChart();
			// Content = layout;
			this.Content = this.GenerateColumnChart();
		}

		public ScrollView GenerateColumnChart()
		{
			var plotModel = new PlotModel
			{
				Title = "Chart",
				Subtitle = string.Format("OS: {0}, Idiom: {1}", Device.OS, Device.Idiom),
				Background = OxyColors.LightYellow,
				PlotAreaBackground = OxyColors.LightGray
			};
			var categoryAxis = new CategoryAxis { Position = AxisPosition.Bottom };
			var valueAxis = new LinearAxis { Position = AxisPosition.Left, MinimumPadding = 0 };
			plotModel.Axes.Add(categoryAxis);
			plotModel.Axes.Add(valueAxis);
			var series = new ColumnSeries();

			series.Items.Add(new ColumnItem { Value = 3 });
			series.Items.Add(new ColumnItem { Value = 14 });
			series.Items.Add(new ColumnItem { Value = 11 });
			series.Items.Add(new ColumnItem { Value = 12 });
			series.Items.Add(new ColumnItem { Value = 7 });
			plotModel.Series.Add(series);


			var series2 = new ColumnSeries();

			series2.Items.Add(new ColumnItem { Value = 15 });
			series2.Items.Add(new ColumnItem { Value = 10 });
			series2.Items.Add(new ColumnItem { Value = 5 });
			series2.Items.Add(new ColumnItem { Value = 18 });
			series2.Items.Add(new ColumnItem { Value = 190 });

			plotModel.Series.Add(series2);

			var c = new OxyPlotView()
			{
				Model = plotModel,
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.Fill,
			};

			var nameLayout = new ScrollView()
			{
				Content = new StackLayout()
				{
					// WidthRequest = 320,
					Padding = new Thickness(0, 20, 0, 0),
					HorizontalOptions = LayoutOptions.Fill,
					VerticalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Vertical,
					Children = { c },
					BackgroundColor = Color.Gray
				}
			};

			return nameLayout;
		}
	}
}

