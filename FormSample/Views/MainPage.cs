using System;
using FormSample.Helpers;
using FormSample.Views;
using Xamarin.Forms;

namespace FormSample
{
	public class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			var menuPage = new MenuPage();
			menuPage.Menu.ItemSelected += (sender, e) =>
			{
				NavigateTo(e.SelectedItem as string);
			};
			Master = menuPage;

			this.NavigateTo("Home");
		}

		public void NavigateTo(string item)
		{
			Page page = new HomePage();
			switch (item)
			{
			case "Home":
				page = new HomePage();
				break;
			case "Refer a contractor":
				page = new ContractorPage ();
				break;
			case "My contractors":
				page = new MyContractorPage ();
				break;
				//case "Amend details":
				//    master.Detail = new NavigationPage(new ChartPage()) { BarBackgroundColor = App.NavTint };
				//    break;
				//case "Terms & Conditions":
				//    master.Detail = new NavigationPage(new ChartPage()) { BarBackgroundColor = App.NavTint };
				//    break;
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
			case "Logout":
				Settings.GeneralSettings = string.Empty;
				// page = new LoginPage();
				break;
			}

			this.Detail = new NavigationPage(page);
			this.IsPresented = false;
		}
	}
}

