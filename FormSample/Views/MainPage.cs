using System;
using FormSample.Helpers;
using FormSample.Views;
using Xamarin.Forms;

namespace FormSample
{
	public class MainPage : MasterDetailPage
	{
		MenuPage menuPage;
		public MainPage()
		{
			this.ShowLoginPage ();
			//var menuPage = new MenuPage ();
			menuPage = new MenuPage ();
				menuPage.Menu.ItemSelected += (sender, e) => {
					NavigateTo (e.SelectedItem as string);
				};
				Master = menuPage;
				this.NavigateTo ("Home");

		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
		}

		public async void ShowLoginPage()
		{
			if (string.IsNullOrWhiteSpace(Settings.GeneralSettings))
			{
				var page = new LoginPage();
				await Navigation.PushModalAsync(page);
			}
		}

		public void NavigateTo(string item)
		{
			Page page = new HomePage();
			menuPage.Menu.SelectedItem = item;
			switch (item)
			{

			case "Refer a contractor":
				page = new ContractorPage ();
				break;
			case "My contractors":
				page = new MyContractorPage ();

				break;
			case "Amend my details":
				page = new AmendDetailsPage ();
				    break;
			case "About us":
				page = new AboutusPage ();
				break;
			case "Contact us":
				page = new ContactUsPage ();
				break;
			case "Take home pay calculator":
				page = new CalculatorPage ();
				break;
            case "Weekly pay chart":
                page = new ChartPage();
                break;
			case "Log out":
				Settings.GeneralSettings = string.Empty;
				// page = new LoginPage();
				break;
			default:
				menuPage.Menu.SelectedItem = item;
				page = new HomePage();
				break;

			}
			this.Detail = new NavigationPage(page);
			this.IsPresented = false;
		}
	}
}

