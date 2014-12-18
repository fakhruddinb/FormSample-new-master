using System;
using Xamarin.Forms;

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
				page = new MainPage();
				RootPage = new MainPage();
            }
            catch (Exception ex)
            {
            }
            return page;
        }
    }

}

