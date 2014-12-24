using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;
namespace FormSample
{
	public class ContractorCell : ViewCell
	{
		public ContractorCell()
		{
//			var image = new Image
//			{
//				HorizontalOptions = LayoutOptions.Start
//			};
//			image.SetBinding(Image.SourceProperty, new Binding("ProfilePicture"));
//			image.WidthRequest = image.HeightRequest = 40;
//			var checkBox = new CheckBox();
//			checkBox.TextColor = Color.White;
			var nameLayout = CreateLayout();
			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children = { nameLayout }
			};
			viewLayout.BackgroundColor = MyContractorPage.counter % 2 == 0 ? Color.Silver: Color.Gray ;
			MyContractorPage.counter++;
			View = viewLayout;
		}
		private StackLayout CreateLayout()
		{
			var nameLabel = new Label { HorizontalOptions = LayoutOptions.FillAndExpand };
			nameLabel.SetBinding(Label.TextProperty, new Binding("FirstName"));
			nameLabel.WidthRequest = 100;
			nameLabel.TextColor = Color.Black;

			var referDateLabel = new Label { HorizontalOptions = LayoutOptions.FillAndExpand };
			referDateLabel.SetBinding(Label.TextProperty, new Binding("InsertDate"));
			referDateLabel.TextColor = Color.Black;

			var contractorIdLabel = new Label ();
			contractorIdLabel.SetBinding(Label.TextProperty, new Binding("Id"));
			contractorIdLabel.IsVisible = false;

			var nameLayout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = { nameLabel, referDateLabel, contractorIdLabel }
			};
			return nameLayout;
		}
//		protected override void OnTapped()
//		{
//			base.OnTapped();
//			var entry = (BindingContext as Contractor);
//			var dataService = new ContractorDataService ();
//
//			//TODO: Show confirm dialog
//			var result =  dataService.DeleteContractor (entry.Id, entry.AgentId);
//			//TODO: refresh page grid
//			App.Navigation.PushAsync(new MyContractorPage());
//			// App.Navigation.PushAsync(new ChartPage());
//		}
	}
}