using System;
using Xamarin.Forms;
using FormSample.ViewModel;
using FormSample.Helpers;
using System.Threading.Tasks;

namespace FormSample
{
	public class AmendDetailsPage : ContentPage
	{

		private AgentViewModel agentViewModel;
		private DataService dataService;
		Entry firstName ;
		Entry lastName;
		Entry email;
		Entry phone;
		Entry agencyName;
		int id;

		public AmendDetailsPage ()
		{
			this.BackgroundColor = Color.White;

			agentViewModel = new AgentViewModel (Navigation);
			dataService = new DataService ();
			var layout = this.AssignValues();
			this.Content = layout;
		}

		public ScrollView AssignValues()
		{
			BindingContext = new AgentViewModel (Navigation);


			var label = new Label
			{
				Text = "Amend Details",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				TextColor = Color.White,
				BackgroundColor = Color.Black,
				VerticalOptions = LayoutOptions.Center,
				XAlign = TextAlignment.Center, // Center the text in the blue box.
				YAlign = TextAlignment.Center, // Center the text in the blue box.
			};

			var firstNameLabel = new Label { HorizontalOptions = LayoutOptions.Fill, TextColor=Color.Black};
			firstNameLabel.Text = "First Name";

			var lastNameLabel = new Label { HorizontalOptions = LayoutOptions.Fill, TextColor=Color.Black };
			lastNameLabel.Text = "Last Name";

			this.firstName = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			//firstName.SetBinding(Entry.TextProperty, new Binding(AgentViewModel.FirstNamePropertyName));


			this.lastName = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			// lastName.SetBinding(Entry.TextProperty, AgentViewModel.LastNamePropertyName,BindingMode.TwoWay);

			var emailLabel = new Label { HorizontalOptions = LayoutOptions.Fill, TextColor=Color.Black };
			emailLabel.Text = "Email";

			this.email= new Entry { HorizontalOptions = LayoutOptions.FillAndExpand  };
			// emailText.SetBinding(Entry.TextProperty, AgentViewModel.AgentEmailPropertyName,BindingMode.TwoWay);
			this.email.IsEnabled = false;

			var agencyLabel = new Label { HorizontalOptions = LayoutOptions.Fill , TextColor=Color.Black};
			agencyLabel.Text = "Agency";

			this.agencyName = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			//agencyText.SetBinding(Entry.TextProperty, AgentViewModel.AgencyNamePropertyName,BindingMode.TwoWay);

			var phoneLabel = new Label { HorizontalOptions = LayoutOptions.Fill, TextColor=Color.Black };
			phoneLabel.Text = "Phone number";

			this.phone = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand};
			//phoneText.SetBinding(Entry.TextProperty, AgentViewModel.PhonePropertyName,BindingMode.TwoWay);
			this.phone.Keyboard = Keyboard.Telephone;
			this.BindAgent();



			Button btnUpdate = new Button
			{
				HorizontalOptions = LayoutOptions.Fill,
				BackgroundColor = Color.FromHex("22498a"),
				Text = "Update"
			};
			btnUpdate.Clicked += async (object sender, EventArgs e) => 
			{
				await  ExecuteUpdateCommand();
			};

			//  btnUpdate.SetBinding(Button.CommandProperty, AgentViewModel.UpdateCommandPropertyName);

			var downloadButton = new Button { Text = "Download Terms and Conditions", BackgroundColor = Color.FromHex("f7941d"), TextColor = Color.White };
			downloadButton.SetBinding (Button.CommandProperty, AgentViewModel.GotoDownloadCommandPropertyName);

			var contactUsButton = new Button { Text = "Contact Us", BackgroundColor = Color.FromHex("0d9c00"), TextColor = Color.White };
			contactUsButton.SetBinding (Button.CommandProperty, AgentViewModel.GotoContactUsCommandPropertyName);

			var nameLayout = new StackLayout()
			{
				// WidthRequest = 320,
				//Padding = new Thickness(0, 0, 0, 0),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = 
				{ label, emailLabel, email, firstNameLabel, firstName, lastNameLabel, lastName, agencyLabel, 
					agencyName, phoneLabel, phone, btnUpdate, downloadButton, contactUsButton },

			};
			return new ScrollView{Content= nameLayout};
			//agentObj =  BindAgent ();
		}


		private void BindAgent()
		{
			AgentDatabase d = new AgentDatabase();
			var agentToUpdate = d.GetAgentByEmail(Settings.GeneralSettings);
			if (agentToUpdate != null)
			{
				id = agentToUpdate.Id;

				firstName.Text = agentToUpdate.FirstName;
				lastName.Text = agentToUpdate.LastName;
				email.Text = agentToUpdate.Email;
				agencyName.Text = agentToUpdate.AgencyName;
				phone.Text = agentToUpdate.Phone;
			}
		}

		private async Task ExecuteUpdateCommand()
		{
			try{

				bool isValid = true;
				string errorMessage = string.Empty;

				if (string.IsNullOrWhiteSpace(this.firstName.Text))
				{
					errorMessage = errorMessage + "Firstname is required.\n";
				}

				if (string.IsNullOrWhiteSpace(this.lastName.Text))
				{
					errorMessage = errorMessage + "Lastname is required.\n";
				}

				if (string.IsNullOrWhiteSpace(this.agencyName.Text))
				{
					errorMessage = errorMessage + "Agency name is required.\n";
				}

				if (!string.IsNullOrEmpty(errorMessage))
				{
					isValid = false;
					await this.DisplayAlert("Message", errorMessage, "OK");
				}
				else
				{
					var a = new Agent()
					{
						Id = this.id,
						Email = this.email.Text,
						FirstName = this.firstName.Text,
						LastName = this.lastName.Text,
						Phone = this.phone.Text,
						AgencyName = this.agencyName.Text
					};

					var networkService = DependencyService.Get<FormSample.Helpers.Utility.INetworkService>().IsReachable();
					if (networkService)
					{
						await dataService.UpdateAgent(a);
					}

					UpdateAgent(a);

					App.RootPage.NavigateTo("Home");
				}
			}
			catch {
			}
		}
		private void UpdateAgent(Agent agentToUpdate)
		{
			AgentDatabase agent = new AgentDatabase();
			agent.SaveItem(agentToUpdate);
		}
	}
}

