using FormSample.Helpers;

namespace FormSample
{
    using FormSample.ViewModel;
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Labs.Controls;

    public class MyContractorPage : ContentPage
    {
        public static int counter { get; set; }
        private ContractorViewModel contractorViewModel;
		private ContractorDataService dataService = new ContractorDataService();
        private ListView listView;
       
//		public MyContractorPage()
//        {
//			contractorViewModel = new ContractorViewModel();
//            counter = 1;
//
//          
//
//			var label = new Label{ Text = "My contractor",BackgroundColor = Color.Gray,Font = Font.SystemFontOfSize(NamedSize.Medium),
//				TextColor = Color.White,
//				VerticalOptions = LayoutOptions.Center,
//				XAlign = TextAlignment.Center, // Center the text in the blue box.
//				YAlign = TextAlignment.Center
//			};
//            listView = new ListView
//            {
//                RowHeight = 40
//            };
//            var grid = new Grid
//            {
//                ColumnSpacing = 200
//            };
//            grid.Children.Add(new Label { Text = "Contractor", TextColor=Color.Red }, 0, 0); // Left, First element
//			grid.Children.Add(new Label { Text = "Date refered" ,TextColor=Color.Red}, 1, 0);
//
//            var btnClearAllContractor = new Button { Text = "Clear all contractor", BackgroundColor = Color.FromHex("3b73b9"), TextColor = Color.White };
//			btnClearAllContractor.SetBinding (Button.CommandProperty, ContractorViewModel.GotoDeleteAllContractorCommandPropertyName);
//
//            var downloadButton = new Button { Text = "Download Terms and Conditions", BackgroundColor = Color.FromHex("f7941d"), TextColor = Color.White };
//
//            var contactUsButton = new Button { Text = "Contact Us", BackgroundColor = Color.FromHex("0d9c00"), TextColor = Color.White };
//			contactUsButton.SetBinding (Button.CommandProperty, ContractorViewModel.GotoContactUsCommandPropertyName);
//
//            var nameLayOut = new StackLayout
//            {
////                Orientation = StackOrientation.Vertical,
////                Children = { btnClearAllContractor, downloadButton, contactUsButton }
//					VerticalOptions = LayoutOptions.FillAndExpand,
//				Children = {label, grid, listView, btnClearAllContractor, downloadButton, contactUsButton }
//            };
//
//            Content = new ScrollView
//            {
//				Content = nameLayOut
//            };
//
//            listView.ItemTapped += async (sender, args) =>
//            {
//                var contractor = args.Item as Contractor;
//                if (contractor == null)
//                {
//                    return;
//                }
//
//                var answer = await DisplayAlert("Confirm", "Do you wish to clear this item", "Yes", "No");
//                if (answer)
//                {
//					var result = await dataService.DeleteContractor(contractor.Id, Settings.GeneralSettings);
//					if(result != null)
//					{
//                   await this.contractorViewModel.DeleteContractor(contractor.Id);
//						listView.ItemsSource = this.contractorViewModel.contractorList;
//					}
//                }
//
//                listView.SelectedItem = null;
//            };
//
//        }


		public MyContractorPage()
		{
			contractorViewModel = new ContractorViewModel();
			counter = 1;

			var label = new Label{ Text = "My contractor",BackgroundColor = Color.Black,Font = Font.SystemFontOfSize(NamedSize.Large),
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.Center,
				XAlign = TextAlignment.Center, // Center the text in the blue box.
				YAlign = TextAlignment.Center
			};

			var labelStakeLayout = new StackLayout (){ 
				Children = {label}
			};

			listView = new ListView
			{
				RowHeight = 40
			};
			var grid = new Grid
			{
				ColumnSpacing = 100
			};
			grid.Children.Add(new Label { Text = "Contractor", TextColor=Color.Red }, 0, 0); // Left, First element
			grid.Children.Add(new Label { Text = "Date refered" ,TextColor=Color.Red}, 1, 0);

			var btnClearAllContractor = new Button { Text = "Clear all contractor", BackgroundColor = Color.FromHex("3b73b9"), TextColor = Color.White };
			btnClearAllContractor.SetBinding (Button.CommandProperty, ContractorViewModel.GotoDeleteAllContractorCommandPropertyName);

			var downloadButton = new Button { Text = "Download Terms and Conditions", BackgroundColor = Color.FromHex("f7941d"), TextColor = Color.White };

			var contactUsButton = new Button { Text = "Contact Us", BackgroundColor = Color.FromHex("0d9c00"), TextColor = Color.White };

			contactUsButton.Clicked += delegate
			{
				App.RootPage.NavigateTo("Contact us");
			};

			var controlStakeLayout = new StackLayout (){ 
				Padding = new Thickness(10, 0, 10, 0),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { grid, listView, btnClearAllContractor, downloadButton, contactUsButton }
			};

			var nameLayOut = new StackLayout
			{
				//                Orientation = StackOrientation.Vertical,
				//                Children = { btnClearAllContractor, downloadButton, contactUsButton }
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {labelStakeLayout,controlStakeLayout}
			};

			Content = new ScrollView
			{
				Content = nameLayOut
			};

			listView.ItemTapped += async (sender, args) =>
			{
				var contractor = args.Item as Contractor;
				if (contractor == null)
				{
					return;
				}

				var answer = await DisplayAlert("Confirm", "Do you wish to clear this item", "Yes", "No");
				if (answer)
				{
					var result = await dataService.DeleteContractor(contractor.Id, Settings.GeneralSettings);
					if(result != null)
					{
						await this.contractorViewModel.DeleteContractor(contractor.Id);
						listView.ItemsSource = this.contractorViewModel.contractorList;
					}
				}

				listView.SelectedItem = null;
			};

		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
			var x = DependencyService.Get<FormSample.Helpers.Utility.INetworkService>().IsReachable();
			if (!x) {
				await DisplayAlert ("Message", "Could not connect to the internet.", "OK");
			} else {
				await this.contractorViewModel.BindContractor ();
				listView.ItemTemplate = new DataTemplate (typeof(ContractorCell));
				listView.ItemsSource = this.contractorViewModel.contractorList;
			}
        }

       
    }
}
