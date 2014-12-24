using System;
using Xamarin.Forms;
using FormSample.Views;
using System.Collections.Generic;

//namespace FormSample.Views
//{
//    using System.Collections.Generic;
//    using Xamarin.Forms;
//    /// <summary>
//    /// Required for PlatformRenderer
//    /// </summary>
//    public class MenuTableView : TableView
//    {
//    }
//    /// <summary>
//    /// The menu page.
//    /// </summary>
//    public class MenuPage : ContentPage
//    {
//        #region Fields
//        /// <summary>
//        /// The master.
//        /// </summary>
//        private readonly MasterDetailPage master;
//        /// <summary>
//        /// The table view.
//        /// </summary>
//        private TableView tableView;
//        public ListView Menu { get; set; }
//        #endregion
//        #region Constructors and Destructors
//        /// <summary>
//        /// Initializes a new instance of the <see cref="MenuPage"/> class.
//        /// </summary>
//        public MenuPage()
//        {
//            // this.master = new MasterDetailPage();
//            Title = "Mobile Recruiter";
//            Icon = "MenuIcon.png";;
//            var itemList = new List<string>  { "Home", "Refer a contractor", "My contractors","Amend my details","Terms and conditions",
//                                                "About us","Contact us","Take home pay calculator","Weekly pay chart"};
//            Menu = new ListView() { ItemsSource = itemList };
//            this.Content = new StackLayout
//            {
//                BackgroundColor = Color.Gray,
//                VerticalOptions = LayoutOptions.FillAndExpand,
//                Children = {
//Menu
//}
//            };
//        }
//        #endregion
//        #region Public Methods and Operators
//        /// <summary>
//        /// The selected.
//        /// </summary>
//        /// <param name="item">
//        /// The item.
//        /// </param>
//        public void Selected(string item)
//        {
//            switch (item)
//            {
//                case "Home":
//                    this.master.Detail = new NavigationPage(new HomePage()) { BarBackgroundColor = App.NavTint };
//                    break;
//                case "Refer a contractor":
//                    this.master.Detail = new NavigationPage(new ContractorPage()) { BarBackgroundColor = App.NavTint };
//                    break;
//                case "My contractors":
//                    this.master.Detail = new NavigationPage(new MyContractorPage()) { BarBackgroundColor = App.NavTint };
//                    break;
//                case "Amend my details":
//                    this.master.Detail = new NavigationPage(new MyContractorPage()) { BarBackgroundColor = App.NavTint };
//                    break;
//                case "Terms and conditions":
//                    this.master.Detail = new NavigationPage(new LoginPage()) { BarBackgroundColor = App.NavTint };
//                    break;
//                case "About us":
//                    this.master.Detail = new NavigationPage(new AboutusPage()) { BarBackgroundColor = App.NavTint };
//                    break;
//                case "Contact us":
//                    this.master.Detail = new NavigationPage(new ContactUsPage()) { BarBackgroundColor = App.NavTint };
//                    break;
//                case "Take home pay calculator":
//                    this.master.Detail = new NavigationPage(new CalculatorPage()) { BarBackgroundColor = App.NavTint };
//                    break;
//                case "Weekly pay chart":
//                    this.master.Detail = new NavigationPage(new ChartPage()) { BarBackgroundColor = App.NavTint };
//                    break;
//            }
//            this.master.IsPresented = false;
//        }
//        #endregion
//    }
//    /// <summary>
//    /// The menu cell.
//    /// </summary>
//    public class MenuCell : ViewCell
//    {
//        #region Fields
//        /// <summary>
//        /// The label.
//        /// </summary>
//        private readonly Label label;
//        #endregion
//        #region Constructors and Destructors
//        /// <summary>
//        /// Initializes a new instance of the <see cref="MenuCell" /> class.
//        /// </summary>
//        public MenuCell()
//        {
//            this.label = new Label { YAlign = TextAlignment.Center, TextColor = Color.White, };
//            var layout = new StackLayout
//            {
//                BackgroundColor = App.HeaderTint,
//                Padding = new Thickness(20, 0, 0, 0),
//                Orientation = StackOrientation.Horizontal,
//                HorizontalOptions = LayoutOptions.StartAndExpand,
//                Children = {
//this.label
//}
//            };
//            this.View = layout;
//        }
//        #endregion
//        #region Public Properties
//        /// <summary>
//        /// Gets or sets the host.
//        /// </summary>
//        public MenuPage Host { get; set; }
//        /// <summary>
//        /// Gets or sets the text.
//        /// </summary>
//        public string Text
//        {
//            get
//            {
//                return this.label.Text;
//            }
//            set
//            {
//                this.label.Text = value;
//            }
//        }
//        #endregion
//        #region Methods
//        /// <summary>
//        /// The on tapped.
//        /// </summary>
//        protected override void OnTapped()
//        {
//            base.OnTapped();
//            this.Host.Selected(this.label.Text);
//        }
//        #endregion
//    }
//    /// <summary>
//    /// The menu header.
//    /// </summary>
//    public class MenuHeader : ViewCell
//    {
//        #region Constructors and Destructors
//        /// <summary>
//        /// Initializes a new instance of the <see cref="MenuHeader"/> class.
//        /// </summary>
//        public MenuHeader()
//        {
//            var label = new Label { Text = "Mobile recruiter", TextColor = Color.Gray, Font = Font.BoldSystemFontOfSize(20) };
//            this.Height = 60;
//            this.View = new StackLayout
//            {
//                Padding = new Thickness(20),
//                BackgroundColor = App.HeaderTint,
//                Children = {
//label
//}
//            };
//        }
//        #endregion
//    }
//}
namespace FormSample
{
    /// <summary>
    /// Required for PlatformRenderer
    /// </summary>
    public class MenuTableView : TableView
    {
    }
    public class MenuPage : ContentPage
    {

        TableView tableView;
        public ListView Menu { get; set; }

        public MenuPage()
        {
            Title = "Mobile Recruiter";
			Icon = "menu_icon";
            var itemList = new List<string> 
            { "Home", "Refer a contractor", "My contractors","Amend my details","Terms and conditions",
                "About us","Contact us","Take home pay calculator","Weekly pay chart","Log out"};
            Menu = new ListView() { ItemsSource = itemList };

			var headerImage = new Image
			{
				Source = ImageSource.FromFile("logo_large_c9y13k30.png")
			};
			var headerContentView = new ContentView
			{
				Content = headerImage
			};

            Content = new StackLayout
            {
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { headerContentView, Menu }
            };
        }

        public class MenuCell : ViewCell
        {
            Label label;
            public string Text
            {
                get { return label.Text; }
                set { label.Text = value; }
            }
            public MenuPage Host { get; set; }
            public MenuCell()
            {
                label = new Label
                {
                    YAlign = TextAlignment.Center,
                    TextColor = Color.White,
                };
                var layout = new StackLayout
                {
                    BackgroundColor = App.HeaderTint,
                    Padding = new Thickness(20, 0, 0, 0),
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Children = { label }
                };
                View = layout;
            }
            //            protected override void OnTapped()
            //            {
            //                base.OnTapped();
            //                Host.Selected(label.Text);
            //            }
        }
        public class MenuHeader : ViewCell
        {
            public MenuHeader()
            {
                var label = new Label()
                {
                    Text = "Mobile recruiter",
                    TextColor = Color.Red,
                    Font = Font.BoldSystemFontOfSize(20)
                };
                Height = 60;
                View = new StackLayout
                {
                    Padding = new Thickness(20),
                    BackgroundColor = App.HeaderTint,
                    Children = { label }
                };
            }
        }
    }
}