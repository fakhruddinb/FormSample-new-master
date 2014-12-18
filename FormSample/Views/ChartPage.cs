namespace FormSample
{
	using OxyPlot;
	using OxyPlot.Axes;
	using OxyPlot.Series;
	using OxyPlot.XamarinForms;
	using Xamarin.Forms;
	public class ChartPage : ContentPage
	{
		public ChartPage ()
		{
			this.Content = this.GeneratePieChart();
		}
		public ScrollView GeneratePieChart()
		{
			var pieChart = new OxyPlotView()
			{
				Model = CreatePieChart(),
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.Fill,
			};

			var pieChart2 = new OxyPlotView()
			{
				Model = CreatePieChart2(),
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.Fill,
			};
			var nameLayout = new ScrollView()
			{
				Content = new StackLayout()
				{
					// WidthRequest = 320,
					Padding = new Thickness(0, 20, 0, 0),
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Vertical,
					Children = { pieChart, pieChart2 },
					BackgroundColor = Color.Gray
				},
			};

			return nameLayout;
		}

		private static PlotModel CreatePieChart()
		{
			var model = new PlotModel { Title = "World population by continent" };

			var ps = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

			ps.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = true });
			ps.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
			ps.Slices.Add(new PieSlice("Asia", 4157));
			ps.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
			ps.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });

			model.Series.Add(ps);
			return model;
		}

		private static PlotModel CreatePieChart2()
		{
			var model = new PlotModel { Title = "Cricket world cup" };

			var ps = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

			ps.Slices.Add(new PieSlice("India", 1030) { IsExploded = true });
			ps.Slices.Add(new PieSlice("Aus", 929) { IsExploded = true });
			ps.Slices.Add(new PieSlice("Srilanka", 4157));
			ps.Slices.Add(new PieSlice("England", 739) { IsExploded = true });
			ps.Slices.Add(new PieSlice("Pakistan", 35) { IsExploded = true });

			model.Series.Add(ps);
			return model;
		}
	}
}

