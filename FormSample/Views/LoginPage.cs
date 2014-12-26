using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormSample.Helpers;

namespace FormSample.Views
{
    using FormSample.ViewModel;
    using Xamarin.Forms;

    public class LoginPage : ContentPage
    {

//        public LoginPage()
//        {
//            //Contractor c = new Contractor();
//            BindingContext = new LoginViewModel(Navigation);
//
//			BackgroundColor = Color.Gray;
//
//            var layout = new StackLayout { Padding = 5 };
//
//            var label = new Label
//                            {
//                                Text = "Sign in",
//				BackgroundColor = Color.Gray,
//                                Font = Font.SystemFontOfSize(NamedSize.Large),
//								TextColor = Color.White,
//                                VerticalOptions = LayoutOptions.Center,
//                                XAlign = TextAlignment.Center, // Center the text in the blue box.
//                                YAlign = TextAlignment.Center, // Center the text in the blue box.
//                            };
//
//            layout.Children.Add(label);
//			var userNameLabel = new Label { HorizontalOptions = LayoutOptions.Fill, TextColor=Color.FromHex("373737")};
//			userNameLabel.Text = "Email";
//
//			var username = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand};
//            username.SetBinding(Entry.TextProperty, LoginViewModel.UsernamePropertyName);
//            username.Keyboard = Keyboard.Email;
//          
//
//			var passwordLabel = new Label { HorizontalOptions = LayoutOptions.Fill, TextColor=Color.FromHex("373737")};
//			passwordLabel.Text = "Password";
//
//			var password = new Entry {HorizontalOptions = LayoutOptions.FillAndExpand };
//            password.SetBinding(Entry.TextProperty, LoginViewModel.PasswordPropertyName);
//            password.IsPassword = true;
//         
//
//			var forgotPassword = new Button { Text = "I have forgotton my password", BackgroundColor=Color.FromHex("3b73b9")};
//			forgotPassword.SetBinding (Button.CommandProperty, LoginViewModel.ForgotPasswordCommandPropertyName);
//
//			var button = new Button { Text = "Sign In",BackgroundColor = Color.FromHex("22498a"),};
//            button.SetBinding(Button.CommandProperty, LoginViewModel.LoginCommandPropertyName);
//
//			var registerButton = new Button { Text = "I don't have a recruiter account..", BackgroundColor=Color.FromHex("3b73b9")};
//            registerButton.SetBinding(Button.CommandProperty, LoginViewModel.GoToRegisterCommandPropertyName);
//
//			var downloadButton = new Button { Text = "Download Terms and Conditions", BackgroundColor = Color.FromHex("f7941d")};
//            downloadButton.SetBinding(Button.CommandProperty, LoginViewModel.GotoDownloadCommandPropertyName);
//
//			var contactUsButton = new Button { Text = "Contact Us", BackgroundColor = Color.FromHex("0d9c00") };
//            contactUsButton.SetBinding(Button.CommandProperty, LoginViewModel.GotoContactUsCommandPropertyName);
//
//			layout.Children.Add (userNameLabel);
//			layout.Children.Add(username);
//			layout.Children.Add (passwordLabel);
//			layout.Children.Add(password);
//            layout.Children.Add(forgotPassword);
//            layout.Children.Add(button);
//            layout.Children.Add(registerButton);
//            layout.Children.Add(downloadButton);
//            layout.Children.Add(contactUsButton);
//            Content = new ScrollView { Content = layout, BackgroundColor = Color.Gray };
//
//        }

		ILoginManager ilm;
		public LoginPage(ILoginManager ilm)
		{
			this.ilm = ilm;
			//Contractor c = new Contractor();
			BindingContext = new LoginViewModel(Navigation,ilm);

			var layout = new StackLayout { };

			var label = new Label
			{
				Text = "Sign in",
				BackgroundColor = Color.Black,
				Font = Font.SystemFontOfSize(NamedSize.Large),
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.Center,
				XAlign = TextAlignment.Center, // Center the text in the blue box.
				YAlign = TextAlignment.Center, // Center the text in the blue box.
			};

			var labelStakeLayout = new StackLayout (){ 
				Children = {label}
			};

			var userNameLabel = new Label { HorizontalOptions = LayoutOptions.Fill};
			userNameLabel.Text = "Email";

			var username = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand};
			username.SetBinding(Entry.TextProperty, LoginViewModel.UsernamePropertyName);
			username.Keyboard = Keyboard.Email;

			var passwordLabel = new Label { HorizontalOptions = LayoutOptions.Fill};
			passwordLabel.Text = "Password";

			var password = new Entry {HorizontalOptions = LayoutOptions.FillAndExpand };
			password.SetBinding(Entry.TextProperty, LoginViewModel.PasswordPropertyName);
			password.IsPassword = true;

			var forgotPassword = new Button { Text = "I have forgotton my password", BackgroundColor=Color.FromHex("3b73b9")};
			forgotPassword.SetBinding (Button.CommandProperty, LoginViewModel.ForgotPasswordCommandPropertyName);

			var loginButton = new Button { Text = "Sign In",BackgroundColor = Color.FromHex("22498a"),};
			loginButton.SetBinding(Button.CommandProperty, LoginViewModel.LoginCommandPropertyName);

			var registerButton = new Button { Text = "I don't have a recruiter account..", BackgroundColor=Color.FromHex("3b73b9")};
			registerButton.SetBinding(Button.CommandProperty, LoginViewModel.GoToRegisterCommandPropertyName);

			var downloadButton = new Button { Text = "Download Terms and Conditions", BackgroundColor = Color.FromHex("f7941d")};
			downloadButton.Clicked += delegate {
				DependencyService.Get<FormSample.Helpers.Utility.IUrlService> ().OpenUrl (Utility.PDFURL);
			};
			//downloadButton.SetBinding(Button.CommandProperty, LoginViewModel.GotoDownloadCommandPropertyName);

			var contactUsButton = new Button { Text = "Contact Us", BackgroundColor = Color.FromHex("0d9c00") };
			contactUsButton.SetBinding(Button.CommandProperty, LoginViewModel.GotoContactUsCommandPropertyName);

			var controlStakeLayout = new StackLayout (){ 
				Padding = new Thickness(10, 0, 10, 0),
				VerticalOptions = LayoutOptions.FillAndExpand, 
				HorizontalOptions = LayoutOptions.Fill,
				Orientation = StackOrientation.Vertical,
				Children = {userNameLabel,username,passwordLabel,password,forgotPassword,loginButton,registerButton,downloadButton,contactUsButton}
			};

			layout.Children.Add(labelStakeLayout);
			layout.Children.Add (controlStakeLayout);

			Content = new ScrollView { Content = layout };

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<LoginViewModel, string>(this, "msg", async (sender, args) => await this.DisplayAlert("Message", args, "OK"));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginViewModel, string>(this, "msg");
        }
    }
}
