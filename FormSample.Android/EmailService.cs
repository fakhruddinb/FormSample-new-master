using Android.Content;
using FormSample.Droid;
using Xamarin.Forms;
using Android.Net;

[assembly: Dependency(typeof(EmailService))]
namespace FormSample.Droid
{
	public class EmailService :FormSample.Helpers.Utility.IEmailService
	{
		public void OpenEmail(string email)
		{
			var intent = new Intent (Intent.ActionView);
			Uri data = Uri.Parse("mailto:"+ email);
			intent.SetData(data);
			Forms.Context.StartActivity(intent);
//			intent.SetType ("message/rfc822");
//			intent.PutExtra (Intent.ActionSendto,email);
//			Forms.Context.StartActivity (Intent.CreateChooser (intent, "Send email"));
		}
	}
}

