using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSample.Views
{
    using System;

    using Xamarin.Forms;

    using Xamarin.Forms.Labs.Controls;

    using FormSample.ViewModel;
   
   public class ContractorPage : ContentPage
    {
       DataService service = new DataService();
      // readonly Contractor contractor;

       public ContractorPage()
       {
           //this.contractor = c;
           var Layout = this.AssignValues();
           this.Content = Layout;
       }

//		public ScrollView AssignValues()
//       {
//          // BindingContext = new ContractorViewModel(Navigation);
//           BindingContext = new ContractorViewModel();
//           var label = new Label
//           {
//               Text = "Refer a contractor",
//				BackgroundColor= Color.Gray,
//               Font = Font.SystemFontOfSize(NamedSize.Medium),
//               TextColor = Color.White,
//               VerticalOptions = LayoutOptions.Center,
//               XAlign = TextAlignment.Center, // Center the text in the blue box.
//               YAlign = TextAlignment.Center // Center the text in the blue box.
//           };
//
//			var firstNameLabel = new Label { HorizontalOptions = LayoutOptions.Fill,TextColor=Color.FromHex("373737") };
//           firstNameLabel.Text = "First Name";
//
//           var firstName = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
//			firstName.SetBinding (Entry.TextProperty, ContractorViewModel.ContractorFirstNamePropertyName);
//           //firstName.Text = contractor.FirstName;
//
//			var lastNameLabel = new Label { HorizontalOptions = LayoutOptions.Fill,TextColor=Color.FromHex("373737") };
//           lastNameLabel.Text = "Last Name";
//
//           var lastName = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
//			lastName.SetBinding (Entry.TextProperty, ContractorViewModel.ContractorLastNamePropertyName);
//           //lastName.Text = contractor.LastName;
//
//			var phoneNoLabel = new Label { HorizontalOptions = LayoutOptions.Fill,TextColor=Color.FromHex("373737") };
//           phoneNoLabel.Text = "Phone";
//
//			var phoneNo = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand};
//			phoneNo.SetBinding (Entry.TextProperty, ContractorViewModel.ContractorPhonePropertyName);
//            phoneNo.Keyboard = Keyboard.Telephone;
//			//phoneNo.Text = contractor.Phone;
//
//			var emailLabel = new Label { HorizontalOptions = LayoutOptions.Fill,TextColor=Color.FromHex("373737") };
//           emailLabel.Text = "Email";
//
//           var email = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
//			email.SetBinding (Entry.TextProperty, ContractorViewModel.ContractorEmailPropertyName);
//            email.Keyboard = Keyboard.Email;
//			//email.Text = contractor.Email;
//
//			var additionalInfoLabel = new Label { HorizontalOptions = LayoutOptions.Fill,TextColor=Color.FromHex("373737") };
//           additionalInfoLabel.Text = "Additional Information";
//
//           var additionalInfo = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand};
//			additionalInfo.SetBinding (Entry.TextProperty, ContractorViewModel.ContractorAdditionalInfoPropertyName);
//			//additionalInfo.Text = contractor.AdditionalInformation;
//
//           var chkInvite = new CheckBox();
//			chkInvite.SetBinding(CheckBox.CheckedProperty,ContractorViewModel.isCheckedPropertyName,BindingMode.TwoWay);
//           chkInvite.DefaultText = "I Agree to the terms and condition";
//           //chkInvite.IsVisible = true;
//
//           Button btnSubmitContractor = new Button
//           {
//               HorizontalOptions = LayoutOptions.Fill,
//               BackgroundColor = Color.FromHex("22498a"),
//               Text = "Submit"
//           };
//           btnSubmitContractor.SetBinding(Button.CommandProperty,ContractorViewModel.SubmitCommandPropertyName);
//
//			var downloadButton = new Button { Text = "Download Terms and Conditions", BackgroundColor =  Color.FromHex("f7941d"), TextColor = Color.White };
//           
//			var contactUsButton = new Button { Text = "Contact Us", BackgroundColor = Color.FromHex("0d9c00"), TextColor = Color.White };
//			contactUsButton.SetBinding (Button.CommandProperty, ContractorViewModel.GotoContactUsCommandPropertyName);
//
//			var nameLayout = new StackLayout()
//           {
//               WidthRequest = 320,
//               Padding = new Thickness(20, 0, 10, 0),
//               HorizontalOptions = LayoutOptions.StartAndExpand,
//               Orientation = StackOrientation.Vertical,
//               Children = {label, firstNameLabel, firstName, lastNameLabel, lastName, phoneNoLabel, phoneNo, emailLabel, email, additionalInfoLabel, additionalInfo, chkInvite, btnSubmitContractor, downloadButton, contactUsButton },
//               BackgroundColor = Color.Gray
//           };
//			return new ScrollView{Content= nameLayout};
//       }
		public ScrollView AssignValues()
		{
			// BindingContext = new ContractorViewModel(Navigation);
			BindingContext = new ContractorViewModel();
			var label = new Label
			{
				Text = "Refer a contractor",
				BackgroundColor= Color.Black,
				Font = Font.SystemFontOfSize(NamedSize.Large),
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.Center,
				XAlign = TextAlignment.Center, // Center the text in the blue box.
				YAlign = TextAlignment.Center // Center the text in the blue box.
			};

			var labelStakeLayout = new StackLayout () {
				Children = { label }
			};

			var firstNameLabel = new Label { HorizontalOptions = LayoutOptions.Fill };
			firstNameLabel.Text = "First Name";

			var firstName = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			firstName.SetBinding (Entry.TextProperty, ContractorViewModel.ContractorFirstNamePropertyName);
			//firstName.Text = contractor.FirstName;

			var lastNameLabel = new Label { HorizontalOptions = LayoutOptions.Fill};
			lastNameLabel.Text = "Last Name";

			var lastName = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			lastName.SetBinding (Entry.TextProperty, ContractorViewModel.ContractorLastNamePropertyName);
			//lastName.Text = contractor.LastName;

			var phoneNoLabel = new Label { HorizontalOptions = LayoutOptions.Fill};
			phoneNoLabel.Text = "Phone";

			var phoneNo = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand};
			phoneNo.SetBinding (Entry.TextProperty, ContractorViewModel.ContractorPhonePropertyName);
			phoneNo.Keyboard = Keyboard.Telephone;
			//phoneNo.Text = contractor.Phone;

			var emailLabel = new Label { HorizontalOptions = LayoutOptions.Fill};
			emailLabel.Text = "Email";

			var email = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			email.SetBinding (Entry.TextProperty, ContractorViewModel.ContractorEmailPropertyName);
			email.Keyboard = Keyboard.Email;
			//email.Text = contractor.Email;

			var additionalInfoLabel = new Label { HorizontalOptions = LayoutOptions.Fill};
			additionalInfoLabel.Text = "Additional Information";

			var additionalInfo = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand};
			additionalInfo.SetBinding (Entry.TextProperty, ContractorViewModel.ContractorAdditionalInfoPropertyName);
			//additionalInfo.Text = contractor.AdditionalInformation;

			var chkInvite = new CheckBox();
			chkInvite.SetBinding(CheckBox.CheckedProperty,ContractorViewModel.isCheckedPropertyName,BindingMode.TwoWay);
			chkInvite.DefaultText = "I Agree to the terms and condition";
			//chkInvite.IsVisible = true;

			Button btnSubmitContractor = new Button
			{
				HorizontalOptions = LayoutOptions.Fill,
				BackgroundColor = Color.FromHex("22498a"),
				Text = "Submit"
			};
			btnSubmitContractor.SetBinding(Button.CommandProperty,ContractorViewModel.SubmitCommandPropertyName);

			var downloadButton = new Button { Text = "Download Terms and Conditions", BackgroundColor =  Color.FromHex("f7941d"), TextColor = Color.White };

			var contactUsButton = new Button { Text = "Contact Us", BackgroundColor = Color.FromHex("0d9c00"), TextColor = Color.White };

			contactUsButton.Clicked += delegate
			{
				App.RootPage.NavigateTo("Contact us");
			};

			var cotrolStakeLayout = new StackLayout () {
				//WidthRequest = 320,
				Padding = new Thickness(10, 0, 10, 0),
				VerticalOptions = LayoutOptions.FillAndExpand, 
				HorizontalOptions = LayoutOptions.Fill,
				Orientation = StackOrientation.Vertical,
				Children = { firstNameLabel, firstName, lastNameLabel, lastName, phoneNoLabel, phoneNo, emailLabel, email, additionalInfoLabel, additionalInfo, chkInvite, btnSubmitContractor, downloadButton, contactUsButton },
			};

			var nameLayout = new StackLayout()
			{
				Children = {labelStakeLayout,cotrolStakeLayout }
			};
			return new ScrollView{Content= nameLayout};
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<ContractorViewModel, string>(this, "msg", (sender, args) => this.DisplayAlert("Message", args, "OK"));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<ContractorViewModel, string>(this, "msg");
        }
    }
}
