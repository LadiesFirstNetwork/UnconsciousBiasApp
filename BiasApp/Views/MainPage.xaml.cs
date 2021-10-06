using BiasApp.Views;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace BiasApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /**
         * Open new pop-up view with menu list.
         */
        private void MenuButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.ShowPopup(new MenuPopup());
        }

        /**
         * Open new pop-up view with about list.
         */
        private void AboutButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.ShowPopup(new AboutPopup());
        }
    }
}
