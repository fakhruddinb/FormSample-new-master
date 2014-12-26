using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services;

namespace FormSample.Helpers
{
    public static class Utility
    {
		public static string PHONENO = "08082717377";
		public static string EMAIL = "agency@churchill-knight.co.uk";
		public static string GOOGLEPLUSURL = "https://plus.google.com/u/0/+Churchill-Knight/about";
		public static string LINKEDINURL = "http://www.linkedin.com/company/churchill-knight-&-associates-ltd?trk=hb_tab_compy_id_1398435";
		public static string PDFURL = "http://www.sandypointrv.ca/uploads/content/maps/documents/phase-1-lot-plans.pdf";
		public static string LATITUDE = "51.5000";
		public static string LONGITUDE = "0.1167";
		public static int DEVICEWIDTH;
		public static int DEVICEHEIGHT;

        public static bool IsValidEmailAddress(string email)
        {
            string pattern = "(\\w[-._\\w]*\\w@\\w[-._\\w]*\\w\\.\\w{2,3})";
            Match emailAddressMatch = Regex.Match(email, pattern);
            return emailAddressMatch.Success;
        }

		public interface INetworkService
		{
			bool IsReachable();
		}
		public interface IDeviceService
		{
			void Call(string phoneNumber);
		}

		public interface IEmailService
		{
			void OpenEmail (string email);
		}

		public interface IUrlService
		{
			void OpenUrl (string url);
		}


		public interface IMapService
		{
			void OpenMap ();
		}
    }
}
