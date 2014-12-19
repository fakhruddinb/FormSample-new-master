using FormSample.Helpers;

namespace FormSample.Views
{
    using Xamarin.Forms;
	using FormSample;
   public class ContactUsPage : ContentPage
    {
		public ContactUsPage()
		{
            //this.Title = "Contact us";
			Label lblTitle = new Label{Text = "Contact us",BackgroundColor= Color.Black, Font = Font.SystemFontOfSize(NamedSize.Medium),
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.Center,
				XAlign = TextAlignment.Center, // Center the text in the blue box.
				YAlign = TextAlignment.Center
			};
            Label label = new Label() { Text = "To speak with a member of our dedicated team:" };
            double width = 350;
            double height = 150;

			var grid = new Grid
			{
				RowSpacing = 5,
				ColumnSpacing = 0
			};

            var phoneNumberImage = new Image()
            {
                WidthRequest = width,
                HeightRequest = height,
                Aspect = Aspect.AspectFill
            };
            phoneNumberImage.Source = ImageSource.FromFile("ContactPhoneNumber.jpg");

			Button callPhoneNo = new Button
			{
				Text = Utility.PHONENO,
				TextColor = Color.Black,
				BackgroundColor = new Color(255, 255, 255, 0.5),// Color.Transparent,
				VerticalOptions = LayoutOptions.End,

			};

			callPhoneNo.Clicked += delegate {
				DependencyService.Get<FormSample.Helpers.Utility.IDeviceService>().Call(Utility.PHONENO);
			};
            var agencyImage = new Image()
            {
                WidthRequest = width,
                HeightRequest = height,
                Aspect = Aspect.AspectFill
            };
            agencyImage.Source = ImageSource.FromFile("ContactAgency.jpg");

			Button agencyEmail = new Button{Text= Utility.EMAIL,TextColor = Color.Black,BackgroundColor = new Color(255, 255, 255, 0.5),
				VerticalOptions = LayoutOptions.End};

			agencyEmail.Clicked += delegate {
				DependencyService.Get<FormSample.Helpers.Utility.IEmailService>().OpenEmail(Utility.EMAIL);
			};

            var contactMapImage = new Image()
            {
                WidthRequest = width,
                HeightRequest = height,
                Aspect = Aspect.AspectFill
            };
            contactMapImage.Source = ImageSource.FromFile("ContactMap.jpg");

			Button mapText = new Button{Text="Map:EN6 1AG",TextColor = Color.Black,BackgroundColor = new Color(255, 255, 255, 0.5),
				VerticalOptions = LayoutOptions.End};

			mapText.Clicked += delegate {
				DependencyService.Get<FormSample.Helpers.Utility.IMapService>().OpenMap();
			};

			var googleImage = new Image () {
				WidthRequest = width,
				HeightRequest = height,
				Aspect = Aspect.AspectFill
			};
			googleImage.Source = ImageSource.FromFile ("Google.png");

			Button googleText = new Button {Text = "Follow us on Google+", TextColor = Color.Black, BackgroundColor = new Color (255, 255, 255, 0.5),
				VerticalOptions = LayoutOptions.End
			};

			googleText.Clicked+= delegate {
				DependencyService.Get<FormSample.Helpers.Utility.IUrlService>().OpenUrl(Utility.GOOGLEPLUSURL);
			};

			var linkedinImage = new Image ()
			{ 
				WidthRequest = width,
				HeightRequest = height,
				Aspect = Aspect.AspectFill
			};
			linkedinImage.Source = ImageSource.FromFile ("LinkedIn.png");

			Button linkdinText = new Button {Text = "Follow us on Linkedin", TextColor = Color.Black, BackgroundColor = new Color (255, 255, 255, 0.5),
				VerticalOptions = LayoutOptions.End
			};

			linkdinText.Clicked += delegate {
				DependencyService.Get<FormSample.Helpers.Utility.IUrlService>().OpenUrl(Utility.LINKEDINURL);
			};

			grid.Children.Add (phoneNumberImage, 0, 0);
			grid.Children.Add (callPhoneNo, 0, 0);
			grid.Children.Add (agencyImage, 0, 1);
			grid.Children.Add (agencyEmail, 0, 1);
			grid.Children.Add (contactMapImage, 0, 2);
			grid.Children.Add (mapText, 0, 2);
			grid.Children.Add (googleImage, 0, 3);
			grid.Children.Add (googleText, 0, 3);
			grid.Children.Add (linkedinImage, 0, 4);
			grid.Children.Add (linkdinText, 0, 4);

			var downloadButton = new Button { Text = "Download Terms and Conditions", BackgroundColor = Color.FromHex("f7941d"), TextColor = Color.White};

            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = 0,
                HorizontalOptions = LayoutOptions.Fill,
				Children = { lblTitle,label, grid, downloadButton }
				//Children = { label, phoneNumberImage,callPhoneNo,agencyImage, contactMapImage, agencyImage, contactMapImage, downloadButton }
            };
            this.Content = new ScrollView { Content = layout };
		}
    }
}
