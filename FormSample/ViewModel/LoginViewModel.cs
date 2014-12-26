using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormSample.Helpers;

namespace FormSample.ViewModel
{
    using System.Diagnostics;

    using FormSample.Views;

    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
		private IProgressService progressService;
        private DataService dataService;
		private UploadService uploadService;
		ILoginManager ilm;
        private INavigation navigation;

		public LoginViewModel(INavigation navigation,ILoginManager ilm)
        {
            this.navigation = navigation;
            this.dataService = new DataService();
			this.uploadService = new UploadService ();
			progressService = DependencyService.Get<IProgressService>();
			this.ilm = ilm;
        }

        public const string UsernamePropertyName = "Username";
        private string username = string.Empty;
        public string Username
        {
            get { return username; }
            set { this.ChangeAndNotify(ref username, value, UsernamePropertyName); }
        }

        public const string PasswordPropertyName = "Password";
        private string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { this.ChangeAndNotify(ref password, value, PasswordPropertyName); }
        }

		private Command forgotPasswordCommand;
		public const string ForgotPasswordCommandPropertyName = "ForgotPasswordCommand";
		public Command ForgotPasswordCommand
		{
			get{ 
				return forgotPasswordCommand ?? (forgotPasswordCommand = new Command (async () => await ExecuteForgotPasswordCommand ()));
			}
		}

		protected async Task ExecuteForgotPasswordCommand()
		{
			try
			{
				bool isValid = true;
				string errorMessage = string.Empty;
				if(string.IsNullOrWhiteSpace(this.Username))
				{
					errorMessage = errorMessage + "Email is required.\n";

				}
				else if (!Utility.IsValidEmailAddress(this.Username))
				{
					errorMessage = errorMessage + "Please enter valid email address.\n";
				}
				else if (await this.dataService.GetAgent(this.Username) == null)
				{
					  errorMessage = "Invalid user.";
				}
				if(!string.IsNullOrEmpty(errorMessage))
				{
					isValid = false;
					MessagingCenter.Send(this,"msg",errorMessage);
				}

				else
				{
					//true hoy to data service thi password sent karvano
				}
			}
			catch {
			}
		}
        private Command loginCommand;
        public const string LoginCommandPropertyName = "LoginCommand";
        public Command LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommand()));
            }
        }

        protected async Task ExecuteLoginCommand()
        {
            try
            {
				this.progressService.Show();
				bool isValid = true;
				string errorMessage = string.Empty;
				if(string.IsNullOrWhiteSpace(this.Username))
				{
					errorMessage = errorMessage + "Username is required.\n";

				}

				else if (!Utility.IsValidEmailAddress(this.Username))
				{
					errorMessage = errorMessage + "Please enter valid email address.\n";
				}

				if(string.IsNullOrWhiteSpace(this.Password))
				{
					errorMessage = errorMessage + "Password is required.";

				}
				if(string.IsNullOrEmpty(errorMessage))
				{

					var x = DependencyService.Get<FormSample.Helpers.Utility.INetworkService>().IsReachable();
					if (!x)
					{
						progressService.Dismiss();
                        MessagingCenter.Send(this, "msg", "Could not connect to the internet.");
                    }
					else
					{
					var agent = await this.dataService.GetAgent(this.Username);
					if (agent == null)
					{
						progressService.Dismiss();
						MessagingCenter.Send(this, "msg", "Invalid user.");
					}
					 
                    else
                    {
                        Settings.GeneralSettings = this.Username;
						this.AddAgentToLocalDatabase(agent);
						await uploadService.UpdatePaytableDataFromService();
						progressService.Dismiss();
						ilm.ShowMainPage();
						//await navigation.PopModalAsync();
                    }
					}
				}
				else
				{
					isValid = false;
					progressService.Dismiss();
					MessagingCenter.Send(this,"msg",errorMessage);
				}

            }
            catch (Exception ex)
            {
				progressService.Dismiss();
            }
        }

        private Command goToRegisterCommand;
        public const string GoToRegisterCommandPropertyName = "GoToRegisterCommand";
        public Command GoToRegisterCommand
        {
            get
            {
                return goToRegisterCommand ?? (goToRegisterCommand = new Command(async () => await ExecuteGoToRegisterCommand()));
            }
        }

        protected async Task ExecuteGoToRegisterCommand()
        {
            try
            {
				//await navigation.PushModalAsync(new RegisterPage());
                //await navigation.PushAsync(new RegisterPage());
				MessagingCenter.Send(this, "Create");
            }
            catch (Exception ex)
            {
            }
        }

		private Command gotoDownloadCommand;
		public const string GotoDownloadCommandPropertyName = "GotoDownloadCommand";
		public Command GotoDownloadCommand
		{
			get{ 
				return gotoDownloadCommand ?? (gotoDownloadCommand = new Command (async() => await ExecuteDownLoadCommand ()));
			} 

		}

		protected async Task ExecuteDownLoadCommand()
		{
			try
			{

			}
			catch {
			}
		}

		private Command gotoContactUsCommand;
		public const string GotoContactUsCommandPropertyName = "GotoContactUsCommand";
		public Command GotoContactUsCommand
		{
			get{ 
				return gotoContactUsCommand ?? (gotoContactUsCommand = new Command(async()=> await ExecuteContactUsCommand()));
			}
		}

		protected async Task ExecuteContactUsCommand()
		{
			try{
				 App.RootPage.NavigateTo("Contact us");
				//await navigation.PopModalAsync();
				//await navigation.PushModalAsync(new ContactUsPage());
				//await navigation.PushAsync(new ContactUsPage());
			}
			catch {
			}
		}

		private void AddAgentToLocalDatabase(Agent responseFromServer)
		{
			FormSample.AgentDatabase d = new AgentDatabase();
			var existingAgent = d.GetAgentByEmail(responseFromServer.Email);
			if(existingAgent==null)
			{ 
				d.SaveItem(responseFromServer); 
			}
		}
      
    }
}
