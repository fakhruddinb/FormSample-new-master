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
		public static string phoneNo = "08082717377";
		public static string email = "agency@churchill-knight.co.uk";

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
    }
}
