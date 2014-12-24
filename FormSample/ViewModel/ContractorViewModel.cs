using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormSample.ViewModel
{
    using System.Diagnostics;

    using FormSample.Views;

    using Xamarin.Forms;
    using FormSample.Helpers;
    using System.Collections.ObjectModel;

   public class ContractorViewModel :BaseViewModel
    {
       private ContractorDataService contractorDataService;
       public ObservableCollection<Contractor> contractorList { get; set; }
       private ContractorDatabase db;
       private INavigation navigation;

       public ContractorViewModel()
       {
          // this.navigation = navigation;
           this.contractorDataService = new ContractorDataService();
           db = new ContractorDatabase();
           contractorList = new ObservableCollection<Contractor>();
           // BindContractor();
       }

       public const string IdPropertyName = "Id";
       private int id = 0;
       public int Id
       {
           get { return id; }
			set { this.ChangeAndNotify(ref this.id, value, IdPropertyName); }
       }

		public const string AgentIdPropertyName = "AgentId";
		private string agentId = string.Empty;

		public string AgentId
       {
			get { return agentId; }
			set { this.ChangeAndNotify(ref agentId, value, AgentIdPropertyName); }
       }

       public const string ContractorFirstNamePropertyName = "ContractorFirstName";
       private string contractorFirstName = string.Empty;

       public string ContractorFirstName
       {
           get { return contractorFirstName; }
           set { this.ChangeAndNotify(ref contractorFirstName, value, ContractorFirstNamePropertyName); }
       }

       public const string ContractorLastNamePropertyName = "ContractorLastName";
       private string contractorLastName = string.Empty;

       public string ContractorLastName
       {
           get { return contractorLastName; }
           set { this.ChangeAndNotify(ref contractorLastName, value, ContractorLastNamePropertyName); }
       }


       public const string ContractorPhonePropertyName = "ContractorPhone";
       private string contractorPhone = string.Empty;

       public string ContractorPhone
       {
           get { return contractorPhone; }
           set { this.ChangeAndNotify(ref contractorPhone, value, ContractorPhonePropertyName); }
       }

       public const string ContractorEmailPropertyName = "ContractorEmail";
       private string contractorEmail = string.Empty;

       public string ContractorEmail
       {
           get { return contractorEmail; }
           set { this.ChangeAndNotify(ref contractorEmail, value, ContractorEmailPropertyName); }
       }

       public const string ContractorAdditionalInfoPropertyName = "ContractorAdditionalInfo";
       private string contractorAdditionalInfo = string.Empty;

       public string ContractorAdditionalInfo
       {
           get { return contractorAdditionalInfo; }
           set { this.ChangeAndNotify(ref contractorAdditionalInfo, value, ContractorAdditionalInfoPropertyName); }
       }

       public const string isCheckedPropertyName = "IsCheckedProperty";
       private bool isChecked = false;
		public bool IsCheckedProperty
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
               return submitCommand ?? (submitCommand = new Command(async () => await ExecuteSubmitCommand1()));
           }
       }

       protected async Task ExecuteSubmitCommand1()
       {
           try
           {
               bool isValid = true;
               string errorMessage = string.Empty;

               if (string.IsNullOrEmpty(this.ContractorEmail))
               {
                   errorMessage = errorMessage + "Email is required.\n";
               }
               else if (!Utility.IsValidEmailAddress(this.ContractorEmail))
               {
                   errorMessage = errorMessage + "Please enter valid email address.\n";
               }

               if (string.IsNullOrEmpty(this.ContractorFirstName))
               {
                   errorMessage = errorMessage + "Firstname is required.\n";
               }
               if (string.IsNullOrEmpty(this.ContractorFirstName))
               {
                   errorMessage = errorMessage + "Lastname is required.\n";
               }

				if (!this.IsCheckedProperty)
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
                   var obj = new Contractor()
                   {

                       Id = this.Id,
                       AgentId = Settings.GeneralSettings,
                       FirstName = this.ContractorFirstName,
                       LastName = this.ContractorLastName,
                       Email = this.ContractorEmail,
                       Phone = this.ContractorPhone,
                       AdditionalInformation = this.ContractorAdditionalInfo,
						InsertDate = DateTime.Now
                   };
					var x = DependencyService.Get<FormSample.Helpers.Utility.INetworkService>().IsReachable();
					if(!x)
					{
						this.CreateContractor(obj);
						App.RootPage.NavigateTo("Home");
					}
					else
					{
					var result= await contractorDataService.AddContractor(obj);
					if (result != null)
					{
							App.RootPage.NavigateTo("Home");
					}
					}
               }
           }
           catch (Exception ex)
           {

           }
       }

		private Command gotoDeleteAllContractorCommand;
		public const string GotoDeleteAllContractorCommandPropertyName = "GotoDeleteAllContractorCommand";
		public Command GotoDeleteAllContractorCommand
		{
			get
			{
				return gotoDeleteAllContractorCommand ?? (gotoDeleteAllContractorCommand = new Command(async () => await ExecuteDeleteAllContractorCommand()));
			}
		}

		protected async Task ExecuteDeleteAllContractorCommand()
		{
			try
			{
				var result = await contractorDataService.DeleteAllContractor(Settings.GeneralSettings);
				App.RootPage.NavigateTo("Home");
				//navigation.PushAsync(new HomePage());
			}
			catch
			{
			}
		}

		private void CreateContractor(Contractor responseFromServer)
		{
			FormSample.ContractorDatabase d = new ContractorDatabase();
			d.SaveItem(responseFromServer); ;
		}

        public async Task DeleteContractor(int id)
        {
            db.DeleteContractor(id);
            //var deletedCustomer = await this.ds.DeleteCustomer(id);
            //var tmp = deletedCustomer;
            await this.BindContractor();
        }

		public  async Task BindContractor()
        {
            // var customerList = await this.ds.GetCustomers();
			var contractorList =  await  contractorDataService.GetContractors(Settings.GeneralSettings);
			var list =  contractorList.Where (c => c.DeleteDate == null).ToList ();
			this.contractorList = new ObservableCollection<Contractor>(list);
        }
    }
}
