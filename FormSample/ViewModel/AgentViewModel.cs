using System;
using FormSample.ViewModel;
using System.Threading.Tasks;
using FormSample.Helpers;

namespace FormSample.ViewModel
{
    using FormSample.Views;

    using Xamarin.Forms;

    public class AgentViewModel : BaseViewModel
    {
        private DataService dataService;

        private INavigation navigation;
        public AgentViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            this.dataService = new DataService();
        }

        public const string IdPropertyName = "Id";
        private int id = 0;
        public int Id
        {
            get { return this.id; }
            set { this.ChangeAndNotify(ref this.id, value, IdPropertyName); }
        }

        public const string AgentEmailPropertyName = "Email";
        private string email = string.Empty;
        public string Email
        {
            get { return this.email; }
            set { this.ChangeAndNotify(ref this.email, value, AgentEmailPropertyName); }
        }

        public const string FirstNamePropertyName = "FirstName";

        private string firstName = string.Empty;
        public string FirstName
        {
            get { return this.firstName; }
            set { this.ChangeAndNotify(ref this.firstName, value, FirstNamePropertyName); }
        }

        public const string LastNamePropertyName = "LastName";
        private string lastName = string.Empty;
        public string LastName
        {
            get { return this.lastName; }
            set { this.ChangeAndNotify(ref this.lastName, value, LastNamePropertyName); }
        }

        public const string PhonePropertyName = "Phone";
        private string phone = string.Empty;
        public string Phone
        {
            get { return this.phone; }
            set { this.ChangeAndNotify(ref this.phone, value, PhonePropertyName); }
        }

        public const string AgencyNamePropertyName = "AgencyName";
        private string agencyName = string.Empty;
        public string AgencyName
        {
            get { return this.agencyName; }
            set { this.ChangeAndNotify(ref this.agencyName, value, AgencyNamePropertyName); }
        }

        public const string isCheckedPropertyName = "IsChecked";
        private bool isChecked = false;
        public bool IsChecked
        {
            get { return this.isChecked; }
            set { this.ChangeAndNotify(ref this.isChecked, value, isCheckedPropertyName); }
        }

        private Command submitCommand;
        public const string SubmitCommandPropertyName = "SubmitCommand";
        public Command SubmitCommand
        {
            get
            {
                return submitCommand ?? (submitCommand = new Command(async () => await ExecuteSubmitCommand()));
            }
        }

        protected async Task ExecuteSubmitCommand()
        {
            try
            {
                bool isValid = true;
                string errorMessage = string.Empty;

                if (string.IsNullOrWhiteSpace(this.Email))
                {
                    errorMessage = errorMessage + "Email is required.\n";
                }
                else if (!Utility.IsValidEmailAddress(this.Email))
                {
                    errorMessage = errorMessage + "Please enter valid email address.\n";
                }

                if (string.IsNullOrWhiteSpace(this.FirstName))
                {
                    errorMessage = errorMessage + "Firstname is required.\n";
                }

                if (string.IsNullOrWhiteSpace(this.LastName))
                {
                    errorMessage = errorMessage + "Lastname is required.\n";
                }

                if (string.IsNullOrWhiteSpace(this.AgencyName))
                {
                    errorMessage = errorMessage + "Agency name is required.\n";
                }
                if (!this.IsChecked)
                {
                    errorMessage = errorMessage + "terms & condition must be checked.";
                }

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    isValid = false;
                    MessagingCenter.Send(this, "msg", errorMessage);
                }
                else
                {
                    if (await this.dataService.GetAgent(this.Email)!=null)
                    {
                        MessagingCenter.Send(this, "msg", "Email already exist.");
                    }
                    else
                    {
                        var a = new Agent()
                        {
                            Id = this.Id,
                            Email = this.Email,
                            FirstName = this.FirstName,
                            LastName = this.LastName,
                            Phone = this.Phone,
                            AgencyName = this.AgencyName
                        };

                        var result = await dataService.AddAgent(a);
						if (result != null && !string.IsNullOrWhiteSpace(this.Email))
                        {
                            this.CreateDatabase(result);
                            Settings.GeneralSettings = this.Email;
                        }


						await navigation.PopAsync();

                    }
                }
            }
            catch (Exception ex)
            {

            }
            //if (await this.dataService.IsValidUser(this.Username, this.Password))
            //{

            //}
        }

        private Command gotoLoginCommand;
        public const string GotoLoginCommandPropertyName = "GotoLoginCommand";
        public Command GotoLoginCommand
        {
            get
            {
                return gotoLoginCommand ?? (gotoLoginCommand = new Command(async () => await ExecuteGotoLoginCommand()));
            }
        }

        protected async Task ExecuteGotoLoginCommand()
        {
            try
            {
                await navigation.PushAsync(new LoginPage());
            }
            catch { }
        }

        private Command gotoDownloadCommand;
        public const string GotoDownloadCommandPropertyName = "GotoDownloadCommand";
        public Command GotoDownloadCommand
        {
            get
            {
                return gotoDownloadCommand ?? (gotoDownloadCommand = new Command(async () => await ExecuteDownLoadCommand()));
            }

        }

        protected async Task ExecuteDownLoadCommand()
        {
            try
            {

            }
            catch
            {
            }
        }

        private Command gotoContactUsCommand;
        public const string GotoContactUsCommandPropertyName = "GotoContactUsCommand";
        public Command GotoContactUsCommand
        {
            get
            {
                return gotoContactUsCommand ?? (gotoContactUsCommand = new Command(async () => await ExecuteContactUsCommand()));
            }
        }

        protected async Task ExecuteContactUsCommand()
        {
            try
            {
                await navigation.PushAsync(new ContactUsPage());
            }
            catch
            {
            }
        }
        /// <summary>
        /// The execute submit command.
        /// </summary>
        /// <returns> The <see cref="Task"/>. </returns>
        private void CreateDatabase(Agent responseFromServer)
        {
            FormSample.AgentDatabase d = new AgentDatabase();
            //var t = d.GetAgents();
            d.SaveItem(responseFromServer); ;
        }


    }

}
