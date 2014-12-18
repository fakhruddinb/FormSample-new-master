
namespace FormSample.Views
{
	using OxyPlot;
	using OxyPlot.Axes;
	using OxyPlot.Series;
	using OxyPlot.XamarinForms;
	using Xamarin.Forms;

  public class CalculatorPage: ContentPage
    {
		public CalculatorPage()
		{

			var label = new Label { Text = "Take home pay calculator", BackgroundColor = Color.Silver, Font = Font.SystemFontOfSize (NamedSize.Medium),
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.Center,
				XAlign = TextAlignment.Center, // Center the text in the blue box.
				YAlign = TextAlignment.Center
			};

			var grid = new Grid
			{
				RowSpacing = 10,
				ColumnSpacing = 50
			};

			var lblDailyRate = new Label{ Text = "Daily Rate", TextColor = Color.White, BackgroundColor = Color.Black };
			var txtDailyRate = new Entry{ Text = "100", TextColor = Color.White, BackgroundColor = Color.Green };

			var lblWeeklyExpense = new Label{ Text = "Weekly Expenses", TextColor = Color.White, BackgroundColor = Color.Black };
			var txtWeeklyExpense = new Entry{ Text = "100", TextColor = Color.White, BackgroundColor = Color.Green };

			grid.Children.Add (lblDailyRate, 0, 0);
			grid.Children.Add (txtDailyRate, 1, 0);
			grid.Children.Add (lblWeeklyExpense,0,1);
			grid.Children.Add (txtWeeklyExpense, 1, 1);

			var lblText = new Label{Text="Your contractor would be a 64.00 better off with a limited company set through us than through an" +
					"umbrella company.click refer a contractor button below.", HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand};

			var chartGrid = new Grid
			{ 
				RowSpacing=10,
				ColumnSpacing =10
			};

			var pieChart = new OxyPlotView ()
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

			chartGrid.Children.Add (pieChart, 0, 0);
			chartGrid.Children.Add (pieChart2, 0, 1);

			var layout = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(0, 0, 0, 0)
			};

			layout.Children.Add (label);
			layout.Children.Add (grid);
			layout.Children.Add (lblText);
			layout.Children.Add (new ScrollView {
				Content = chartGrid,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			});

            Content = new ScrollView { Content = layout };
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

			ps.Slices.Add(new PieSlice("India",1) { IsExploded = true });
			ps.Slices.Add(new PieSlice("Aus", 2) { IsExploded = true });
			ps.Slices.Add(new PieSlice("Srilanka", 3));
			ps.Slices.Add(new PieSlice("England", 4) { IsExploded = true });
			ps.Slices.Add(new PieSlice("Pakistan", 5) { IsExploded = true });

			model.Series.Add(ps);
			return model;
		}
    }
}
