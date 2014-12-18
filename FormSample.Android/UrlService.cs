using System;
using Android.Content;
using Xamarin.Forms;
using FormSample.Droid;

[assembly: Dependency(typeof(UrlService))]
namespace FormSample.Droid
{
	public class UrlService : FormSample.Helpers.Utility.IUrlService
	{
		public void OpenUrl(string url)
		{
			var uri = Android.Net.Uri.Parse (url);
			var intent = new Intent (Intent.ActionView, uri);
			Forms.Context.StartActivity(intent);
		}
	}
}

