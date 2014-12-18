using System;
using Android.Content;
using FormSample.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(MapService))]
namespace FormSample.Droid
{
	public class MapService : FormSample.Helpers.Utility.IMapService
	{
		public MapService ()
		{
		}

		public void OpenMap ()
		{
			var geoUri = Android.Net.Uri.Parse ("geo:51.5000,0.1167");
			var mapIntent = new Intent (Intent.ActionView, geoUri);
			Forms.Context.StartActivity (mapIntent);
		}
	}
}

