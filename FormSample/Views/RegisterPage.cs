namespace FormSample
{
    using FormSample.ViewModel;
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Labs.Controls;

    public class RegisterPage : ContentPage
    {
        DataService service = new DataService();

        public RegisterPage()
        {
            var layout = this.AssignValues();
            this.Content = layout;
        }

        public ScrollView AssignValues()
        {
            BindingContext = new AgentViewModel(Navigation);


            var label = new Label
            {
                Text = "Registration",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                XAlign = TextAlignment.Center, // Center the text in the blue box.
                YAlign = TextAlignment.Center, // Center the text in the blue box.
            };

            var firstNameLabel = new Label { HorizontalOptions = LayoutOptions.Fill };
            firstNameLabel.Text = "First Name";

            var lastNameLabel = new Label { HorizontalOptions = LayoutOptions.Fill };
            lastNameLabel.Text = "Last Name";

            var firstName = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
            firstName.SetBinding(Entry.TextProperty, AgentViewModel.FirstNamePropertyName);

            var lastName = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
            lastName.SetBinding(Entry.TextProperty, AgentViewModel.LastNamePropertyName);

            var emailLabel = new Label { HorizontalOptions = LayoutOptions.Fill };
            emailLabel.Text = "Email";

            var emailText = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
            emailText.SetBinding(Entry.TextProperty, AgentViewModel.AgentEmailPropertyName);
            emailText.Keyboard = Keyboard.Email;

            var agencyLabel = new Label { HorizontalOptions = LayoutOptions.Fill };
            agencyLabel.Text = "Agency";

            var agencyText = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
            agencyText.SetBinding(Entry.TextProperty, AgentViewModel.AgencyNamePropertyName);

            var phoneLabel = new Label { HorizontalOptions = LayoutOptions.Fill };
            phoneLabel.Text = "Phone number";

            var phoneText = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand};
            phoneText.SetBinding(Entry.TextProperty, AgentViewModel.PhonePropertyName);
            phoneText.Keyboard = Keyboard.Telephone;

            var chkInvite = new CheckBox();
            chkInvite.SetBinding(CheckBox.CheckedProperty, AgentViewModel.isCheckedPropertyName,BindingMode.TwoWay);
            chkInvite.DefaultText = "I Agree to the terms and condition";
            chkInvite.IsVisible = true;

            Button btnRegister = new Button
            {
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.FromHex("22498a"),
                Text = "Register"
            };
			btnRegister.SetBinding(Button.CommandProperty, AgentViewModel.SubmitCommandPropertyName);

            var loginButton = new Button {Text="I already have a recruiter account...", BackgroundColor=Color.FromHex("3b73b9"), TextColor= Color.White };
            loginButton.SetBinding(Button.CommandProperty,AgentViewModel.GotoLoginCommandPropertyName);

            var downloadButton = new Button { Text = "Download Terms and Conditions", BackgroundColor = Color.FromHex("f7941d"), TextColor = Color.White };
			downloadButton.SetBinding (Button.CommandProperty, AgentViewModel.GotoDownloadCommandPropertyName);

			var contactUsButton = new Button { Text = "Contact Us", BackgroundColor = Color.FromHex("0d9c00"), TextColor = Color.White };
			contactUsButton.SetBinding (Button.CommandProperty, AgentViewModel.GotoContactUsCommandPropertyName);

            var nameLayout = new StackLayout()
            {
                WidthRequest = 320,
                Padding = new Thickness(20, 0, 10, 0),
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
				Children = {label, emailLabel, emailText, firstNameLabel, firstName, lastNameLabel, lastName, agencyLabel, agencyText, phoneLabel, phoneText, chkInvite, btnRegister, loginButton, downloadButton, contactUsButton },
                BackgroundColor = Color.Gray
            };
            return new ScrollView{Content= nameLayout};
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<AgentViewModel,string>(this,"msg",(sender, args)=>this.DisplayAlert("Message",args,"OK"));
        }

        protected override void OnDisappearing()
        {
				base.OnDisappearing();
            MessagingCenter.Unsubscribe<AgentViewModel, string>(this, "msg");
        }
    }
}