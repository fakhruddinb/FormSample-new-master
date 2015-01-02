using System;
using Android.Content;
using Xamarin.Forms;
using FormSample.Droid;

[assembly: Dependency(typeof(UrlService))]
namespace FormSample.Droid
{
	public class UrlService : FormSample.Helpers.Utility.IUrlService //, FormSample.Helpers.Utility.IpdfService
	{
		public void OpenUrl(string url)
		{
			try
			{
			var uri = Android.Net.Uri.Parse (url);
			var intent = new Intent (Intent.ActionView, uri);
			Forms.Context.StartActivity(intent);
			}
			catch(Exception ex) {
			}
		}


//		public void OpnePdf(string url)
//		{
//			var uri = Android.Net.Uri.Parse (url);
//			Intent intent = new Intent (Intent.ActionView);
//			intent.SetDataAndType(uri, "application/pdf");
//			intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);
//			try
//			{
//				Xamarin.Forms.Forms.Context.StartActivity(intent);
//			}
//			catch (Exception)
//			{
//				Toast.MakeText(Xamarin.Forms.Forms.Context, "No Application Available to View PDF", ToastLength.Short).Show();
//			}
//		}
	}
}

