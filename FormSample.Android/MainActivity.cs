using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FormSample.Helpers;
using Xamarin.Forms;

namespace FormSample.Droid
{
    using global::Android.Content.PM;

    using Xamarin.Forms.Platform.Android;

	//[Activity(Label = "Mobile Recruiter", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize, ScreenOrientation = ScreenOrientation.Portrait)]
	[Activity( MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : AndroidActivity,ILoginManager
    {
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
			this.ActionBar.SetDisplayUseLogoEnabled (true);

            Xamarin.Forms.Forms.Init(this, bundle);
			// SetPage(App.GetMainPage());

			var metrics = Resources.DisplayMetrics;

			int widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
			int heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

			Utility.DEVICEHEIGHT = heightInDp;
			Utility.DEVICEWIDTH = widthInDp;

			if (string.IsNullOrWhiteSpace (Settings.GeneralSettings)) {
				SetPage (App.GetLoginPage (this));
			} else {
				SetPage(App.GetMainPage(this));
			}
        }

		public override ActionBar ActionBar {
			get {
				base.ActionBar.SetDisplayUseLogoEnabled (true);
				return base.ActionBar;
			}
		}

		private int ConvertPixelsToDp(float pixelValue)
		{
			var dp = (int) ((pixelValue)/Resources.DisplayMetrics.Density);
			return dp;
		}

		public override void OnBackPressed ()
		{
//			if (string.IsNullOrWhiteSpace (Settings.GeneralSettings)) {
//				return;
//			}
			base.OnBackPressed ();
		}

		public void ShowMainPage ()
		{
			SetPage (App.GetMainPage (this)); 
		}

		public void ShowLoginPage() 
		{
			SetPage (App.GetLoginPage (this)); 
		}
//
//		public override bool OnKeyDown(Keycode keyCode, KeyEvent e) {
//
//			if (e.KeyCode == Keycode.Back) {
//				// Back
//				MoveTaskToBack(true);
//				return true;
//			}
//			else {
//				// Return
//				return base.OnKeyDown(keyCode, e);
//			}
//		}

    }
}

