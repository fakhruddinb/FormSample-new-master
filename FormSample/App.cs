using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;
using System.Globalization;

namespace FormSample
{
    using FormSample.Helpers;
    using FormSample.Views;
    using System.Threading.Tasks;
    using Xamarin.Forms.Labs;
    using Xamarin.Forms.Labs.Services;

    public class App
    {

        public static INavigation Navigation { get; private set; }

//        private static async Task<bool> IsNetworkAvailable()
//        {
//            var network = Resolver.Resolve<IDevice>().Network;
//            //var dev = Resolver.Resolve<IDevice>().PhoneService;
//            //dev.DialNumber("989898989");
//            var isReachable = await network.IsReachable("www.yahoo.com", TimeSpan.FromSeconds(1));
//            // DisplayAlert("Message",isReachable,"OK")
//            return isReachable;
//
//        }

        public static Color NavTint
        {
            get
            {
                return Color.FromHex("3498DB"); // Xamarin Blue
            }
        }
        public static Color HeaderTint
        {
            get
            {
                return Color.FromHex("2C3E50"); // Xamarin DarkBlue
            }
        }

		public static MainPage RootPage{ get; set;}

        public static Page GetMainPage()
        {
			Page page = null;
            try
            {
				RootPage= new MainPage();
				page  = RootPage;
				//page = new NavigationPage(new StepperDemoPage()); 
            }
            catch (Exception ex)
            {
            }
            return page;
        }

		public class SliderDemo : ContentPage
		{
			public SliderDemo()
			{
				var sliderMain = new ExtendedSlider
				{
					Minimum = 0.0f,
					Maximum = 5.0f,
					Value = 0.0f,
					StepValue = 1.0f,
					HorizontalOptions = LayoutOptions.FillAndExpand,
				};
				var labelCurrentValue = new Label
				{
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					BindingContext = sliderMain,
				};
				labelCurrentValue.SetBinding(Label.TextProperty,
					new Binding("Value", BindingMode.OneWay,
						null, null, "Current Value: {0}"));
				var grid = new Grid
				{
					Padding = 10,
					RowDefinitions =
					{
						new RowDefinition {Height = GridLength.Auto},
					},
					ColumnDefinitions =
					{
						new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
						new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
						new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
						new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
						new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
					},
				};
				for (var i = 0; i < 6; i++)
				{
					var label = new Label
					{
						Text = i.ToString(CultureInfo.InvariantCulture),
					};
					var tapValue = i; // Prevent modified closure
					label.GestureRecognizers.Add(new TapGestureRecognizer
						{
							Command = new Command(() => { sliderMain.Value = tapValue; }),
							NumberOfTapsRequired = 1
						});
					grid.Children.Add(label, i, 0);
				}
				Content = new StackLayout
				{
					Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 10),
					Children = { grid, sliderMain, labelCurrentValue },
					Orientation = StackOrientation.Vertical,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand
				};
			}
		}
		class StepperDemoPage : ContentPage
		{
			Label label;
			public StepperDemoPage()
			{
				Label header = new Label
				{
					Text = "Stepper",
					Font = Font.SystemFontOfSize(50, FontAttributes.Bold),
					HorizontalOptions = LayoutOptions.Center
				};
				Stepper stepper = new Stepper
				{
					Minimum = 100,
					Maximum = 1000,
					Increment = 0.1,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};
				stepper.ValueChanged += OnStepperValueChanged;
				label = new Label
				{
					Text = "Stepper value is 0",
					Font = Font.SystemFontOfSize(NamedSize.Large),
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};
				// Build the page.
				this.Content = new StackLayout
				{
					Children =
					{
						header,
						stepper,
						label
					}
					};
			}
			void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
			{
				label.Text = String.Format("Stepper value is {0:F1}", e.NewValue);
			}
		}

    }

}

