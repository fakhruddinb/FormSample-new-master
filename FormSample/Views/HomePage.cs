using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormSample.Helpers;

namespace FormSample.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Labs.Controls;

    public class HomePage : ContentPage
    {

        int count = 1;

//        public HomePage()
//        {
//            // var t = this.IsNetworkAvailable();
//			Label lblTitle = new Label{Text = "Home",BackgroundColor = Color.Gray, Font = Font.SystemFontOfSize(NamedSize.Medium),
//				TextColor = Color.White,
//				VerticalOptions = LayoutOptions.Center,
//				XAlign = TextAlignment.Center, // Center the text in the blue box.
//				YAlign = TextAlignment.Center
//			};
//            var layout = new StackLayout
//            {
//                Orientation = StackOrientation.Vertical,
//                Padding = new Thickness(0, 0, 0, 0),
//				BackgroundColor = Color.Gray
//            };
//            var grid = new Grid
//            {
//                RowSpacing = 10,
//                ColumnSpacing = 10
//            };
//            double width = 175;
//            double height = 150;
//            Image imgReferContractor = new Image()
//            {
//                WidthRequest = width,
//                HeightRequest = height,
//                Aspect = Aspect.AspectFill
//            };
//            imgReferContractor.Source = ImageSource.FromFile("homeheader.jpg");
//            Button referContractorButton = new Button()
//            {
//                Text = "Refer a contractor",
//                TextColor = Color.Black,
//                BackgroundColor = new Color(255, 255, 255, 0.5),// Color.Transparent,
//                VerticalOptions = LayoutOptions.End
//            };
//            Image imgMyContractor = new Image()
//            {
//                Aspect = Aspect.AspectFill,
//                WidthRequest = width,
//                HeightRequest = height
//            };
//            imgMyContractor.Source = ImageSource.FromFile("MyContractors.jpg");
//            Button myContractorButton = new Button()
//            {
//                Text = "My contractors",
//                TextColor = Color.Black,
//                BackgroundColor = new Color(255, 255, 255, 0.5),// Color.Transparent,
//                VerticalOptions = LayoutOptions.End
//            };
//            Image imgAboutUs = new Image()
//            {
//                WidthRequest = width,
//                HeightRequest = height,
//                Aspect = Aspect.AspectFill
//            };
//            imgAboutUs.Source = ImageSource.FromFile("aboutus.jpg");
//            Button aboutUsButton = new Button()
//            {
//                Text = "About us",
//                TextColor = Color.Black,
//                BackgroundColor = new Color(255, 255, 255, 0.5),// Color.Transparent,
//                VerticalOptions = LayoutOptions.End
//            };
//            Image imgAmendDetail = new Image()
//            {
//                WidthRequest = width,
//                HeightRequest = height,
//                Aspect = Aspect.AspectFill
//            };
//            imgAmendDetail.Source = ImageSource.FromFile("AmendDetail.jpg");
//            Button amendDetailButton = new Button()
//            {
//                Text = "Amend details",
//                TextColor = Color.Black,
//                BackgroundColor = new Color(255, 255, 255, 0.5),// Color.Transparent,
//                VerticalOptions = LayoutOptions.End
//            };
//            Image imgPayChart = new Image()
//            {
//                WidthRequest = width,
//                HeightRequest = height,
//                Aspect = Aspect.AspectFill
//            };
//			imgPayChart.Source = ImageSource.FromFile("Paychart.jpg");
//            Button payChartButton = new Button()
//            {
//                Text = "Pay chart",
//                TextColor = Color.Black,
//                BackgroundColor = new Color(255, 255, 255, 0.5),// Color.Transparent,
//                VerticalOptions = LayoutOptions.End
//            };
//            Image imgPayCalc = new Image()
//            {
//                WidthRequest = width,
//                HeightRequest = height,
//                Aspect = Aspect.AspectFill
//            };
//			imgPayCalc.Source = ImageSource.FromFile("PayCalculator.jpg");
//            Button payCalcButton = new Button()
//            {
//                Text = "Pay calculator",
//                TextColor = Color.Black,
//                BackgroundColor = new Color(255, 255, 255, 0.5),// Color.Transparent,
//                VerticalOptions = LayoutOptions.End
//            };
//            grid.Children.Add(imgReferContractor, 0, 0); // Left, First element
//            grid.Children.Add(referContractorButton, 0, 0);
//            grid.Children.Add(imgMyContractor, 1, 0); // Right, First element new Label { Text = "My Contractors" }
//            grid.Children.Add(myContractorButton, 1, 0);
//            grid.Children.Add(imgAboutUs, 0, 1); // Left, Second element new Label { Text = "About us" }
//            grid.Children.Add(aboutUsButton, 0, 1);
//            grid.Children.Add(imgAmendDetail, 1, 1); // Right, Second element new Label { Text = "Amend detail" }
//            grid.Children.Add(amendDetailButton, 1, 1);
//            grid.Children.Add(imgPayChart, 0, 2); // Left, Thrid element
//            grid.Children.Add(payChartButton, 0, 2);
//            grid.Children.Add(imgPayCalc, 1, 2); // Right, Thrid element
//            grid.Children.Add(payCalcButton, 1, 2);
//
//            var tapGestureRecognizer = new TapGestureRecognizer();
//            tapGestureRecognizer.Tapped += (sender, e) =>
//            {
//				App.RootPage.NavigateTo("Refer a contractor");
//				//this.Navigation.PushAsync(new ContractorPage());
//            };
//            imgReferContractor.GestureRecognizers.Add(tapGestureRecognizer);
//
//            var myContractorGestureRecognizer = new TapGestureRecognizer();
//            myContractorGestureRecognizer.Tapped += (sender, e) => 
//			{
//				App.RootPage.NavigateTo("My contractors");
//				//this.Navigation.PushAsync(new MyContractorPage());
//			};
//            imgMyContractor.GestureRecognizers.Add(myContractorGestureRecognizer);
//
//			var aboutUsGestureRecognizer = new TapGestureRecognizer ();
//			aboutUsGestureRecognizer.Tapped += (sender, e) => {
//				App.RootPage.NavigateTo("About us");
//				//this.Navigation.PushAsync(new AboutusPage());
//			};
//			imgAboutUs.GestureRecognizers.Add (aboutUsGestureRecognizer);
//
//			var payCalculatorGestureRecognizer = new TapGestureRecognizer ();
//			payCalculatorGestureRecognizer.Tapped += (sender, e) => {
//				App.RootPage.NavigateTo("Take home pay calculator");
//				//this.Navigation.PushAsync(new CalculatorPage());
//			};
//			imgPayCalc.GestureRecognizers.Add (payCalculatorGestureRecognizer);
//
//			var payChartGestureReconizer = new TapGestureRecognizer ();
//			payChartGestureReconizer.Tapped += (sender, e) => {
//				App.RootPage.NavigateTo("Weekly pay chart");
//				//this.Navigation.PushAsync(new ChartPage());
//			};
//			imgPayChart.GestureRecognizers.Add (payChartGestureReconizer);
//
//			var downloadButton = new Button { Text = "Download terms and condition", BackgroundColor = Color.FromHex("f7941d"), TextColor = Color.White};
//            downloadButton.Clicked += delegate
//            {
//                downloadButton.Text = string.Format("Thanks! {0} clicks.", count++);
//            };
//
//			var contactUsButton = new Button { Text = "Contact us",BackgroundColor = Color.FromHex("0d9c00"), TextColor = Color.White };
//            contactUsButton.Clicked += delegate
//            {
//				App.RootPage.NavigateTo("Contact us");
//				//this.Navigation.PushAsync(new ContactUsPage());
//            };
//        
//			layout.Children.Add (lblTitle);
//            layout.Children.Add(new ScrollView { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.Fill, Content = grid });
//            layout.Children.Add(downloadButton);
//            layout.Children.Add(contactUsButton);
//            Content = layout;
//        }

		public HomePage()
		{
			BindingContext = new HomeViewModel();
			var Layout = this.AssignValues();
			this.Content = Layout;
		}

		public ScrollView AssignValues()
		{
			// var t = this.IsNetworkAvailable();
			Label lblTitle = new Label{Text = "Home",BackgroundColor = Color.Black, Font = Font.SystemFontOfSize(NamedSize.Large),
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.Center,
				XAlign = TextAlignment.Center, // Center the text in the blue box.
				YAlign = TextAlignment.Center
			};

			var grid = new Grid
			{
				RowSpacing = 10,
				ColumnSpacing = 10
			};
			double width = 175;
			double height = 150;
			Image imgReferContractor = new Image()
			{
				WidthRequest = width,
				HeightRequest = height,
				Aspect = Aspect.AspectFill
			};
			imgReferContractor.Source = ImageSource.FromFile("homeheader.jpg");
			Button referContractorButton = new Button()
			{
				Text = "Refer a contractor",
				TextColor = Color.Black,
				BackgroundColor = new Color(255, 255, 255, 0.5),// Color.Transparent,
				VerticalOptions = LayoutOptions.End
			};
			Image imgMyContractor = new Image()
			{
				Aspect = Aspect.AspectFill,
				WidthRequest = width,
				HeightRequest = height
			};
			imgMyContractor.Source = ImageSource.FromFile("MyContractors.jpg");
			Button myContractorButton = new Button()
			{
				Text = "My contractors",
				TextColor = Color.Black,
				BackgroundColor = new Color(255, 255, 255, 0.5),// Color.Transparent,
				VerticalOptions = LayoutOptions.End
			};
			Image imgAboutUs = new Image()
			{
				WidthRequest = width,
				HeightRequest = height,
				Aspect = Aspect.AspectFill
			};
			imgAboutUs.Source = ImageSource.FromFile("aboutus.jpg");
			Button aboutUsButton = new Button()
			{
				Text = "About us",
				TextColor = Color.Black,
				BackgroundColor = new Color(255, 255, 255, 0.5),// Color.Transparent,
				VerticalOptions = LayoutOptions.End
			};
			Image imgAmendDetail = new Image()
			{
				WidthRequest = width,
				HeightRequest = height,
				Aspect = Aspect.AspectFill
			};
			imgAmendDetail.Source = ImageSource.FromFile("AmendDetail.jpg");
			Button amendDetailButton = new Button()
			{
				Text = "Amend details",
				TextColor = Color.Black,
				BackgroundColor = new Color(255, 255, 255, 0.5),// Color.Transparent,
				VerticalOptions = LayoutOptions.End
			};
			Image imgPayChart = new Image()
			{
				WidthRequest = width,
				HeightRequest = height,
				Aspect = Aspect.AspectFill
			};
			imgPayChart.Source = ImageSource.FromFile("Paychart.jpg");
			Button payChartButton = new Button()
			{
				Text = "Pay chart",
				TextColor = Color.Black,
				BackgroundColor = new Color(255, 255, 255, 0.5),// Color.Transparent,
				VerticalOptions = LayoutOptions.End
			};
			Image imgPayCalc = new Image()
			{
				WidthRequest = width,
				HeightRequest = height,
				Aspect = Aspect.AspectFill
			};
			imgPayCalc.Source = ImageSource.FromFile("PayCalculator.jpg");
			Button payCalcButton = new Button()
			{
				Text = "Pay calculator",
				TextColor = Color.Black,
				BackgroundColor = new Color(255, 255, 255, 0.5),// Color.Transparent,
				VerticalOptions = LayoutOptions.End
			};
			grid.Children.Add(imgReferContractor, 0, 0); // Left, First element
			grid.Children.Add(referContractorButton, 0, 0);
			grid.Children.Add(imgMyContractor, 1, 0); // Right, First element new Label { Text = "My Contractors" }
			grid.Children.Add(myContractorButton, 1, 0);
			grid.Children.Add(imgAboutUs, 0, 1); // Left, Second element new Label { Text = "About us" }
			grid.Children.Add(aboutUsButton, 0, 1);
			grid.Children.Add(imgAmendDetail, 1, 1); // Right, Second element new Label { Text = "Amend detail" }
			grid.Children.Add(amendDetailButton, 1, 1);
			grid.Children.Add(imgPayChart, 0, 2); // Left, Thrid element
			grid.Children.Add(payChartButton, 0, 2);
			grid.Children.Add(imgPayCalc, 1, 2); // Right, Thrid element
			grid.Children.Add(payCalcButton, 1, 2);

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (sender, e) =>
			{
				App.RootPage.NavigateTo("Refer a contractor");
				//this.Navigation.PushAsync(new ContractorPage());
			};
			imgReferContractor.GestureRecognizers.Add(tapGestureRecognizer);

			var myContractorGestureRecognizer = new TapGestureRecognizer();
			myContractorGestureRecognizer.Tapped += (sender, e) => 
			{
				App.RootPage.NavigateTo("My contractors");
				//this.Navigation.PushAsync(new MyContractorPage());
			};
			imgMyContractor.GestureRecognizers.Add(myContractorGestureRecognizer);

			var aboutUsGestureRecognizer = new TapGestureRecognizer ();
			aboutUsGestureRecognizer.Tapped += (sender, e) => {
				App.RootPage.NavigateTo("About us");
				//this.Navigation.PushAsync(new AboutusPage());
			};
			imgAboutUs.GestureRecognizers.Add (aboutUsGestureRecognizer);

			var payCalculatorGestureRecognizer = new TapGestureRecognizer ();
			payCalculatorGestureRecognizer.Tapped += (sender, e) => {
				App.RootPage.NavigateTo("Take home pay calculator");
				//this.Navigation.PushAsync(new CalculatorPage());
			};
			imgPayCalc.GestureRecognizers.Add (payCalculatorGestureRecognizer);

			var payChartGestureReconizer = new TapGestureRecognizer ();
			payChartGestureReconizer.Tapped += (sender, e) => {
				App.RootPage.NavigateTo("Weekly pay chart");
				//this.Navigation.PushAsync(new ChartPage());
			};
			imgPayChart.GestureRecognizers.Add (payChartGestureReconizer);

			var downloadButton = new Button { Text = "Download terms and condition", BackgroundColor = Color.FromHex("f7941d"), TextColor = Color.White};
			downloadButton.Clicked += delegate
			{
				downloadButton.Text = string.Format("Thanks! {0} clicks.", count++);
			};

			var contactUsButton = new Button { Text = "Contact us", BackgroundColor = Color.FromHex("0d9c00"), TextColor = Color.White };
			contactUsButton.SetBinding (Button.CommandProperty, HomeViewModel.GotoContactUsCommandPropertyName);
//			contactUsButton.Clicked += (object sender, EventArgs e) => 
//			{
//				App.RootPage.NavigateTo("Contact us");
//				//this.Navigation.PushAsync(new ContactUsPage());
//			};

			var labelStakeLayout = new StackLayout (){ 
				//Children = {lblTitle,new ScrollView { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.Fill, Content = grid }}
				Children = {lblTitle,grid }
			};

			var controlStakeLayout = new StackLayout () {
				Padding = new Thickness(10, 0, 10, 0),
				VerticalOptions = LayoutOptions.FillAndExpand, 
				HorizontalOptions = LayoutOptions.Fill,
				Orientation = StackOrientation.Vertical,
				Children = {downloadButton,contactUsButton }
			};

			var layout = new StackLayout
			{
				Children = {labelStakeLayout,controlStakeLayout}
			};

			return new ScrollView{ Content = layout};
		}
    }
}
