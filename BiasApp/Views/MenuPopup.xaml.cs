using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPopup : Popup
    {
        public MenuPopup()
        {
            InitializeComponent();
        }

        /**
         * Push view with different playing options. 
         * Playing with all cards or one specific category of cards.
         */
        private void PlayPageButton_Clicked(object sender, System.EventArgs e)
        {
            //TODO
        }

        /**
         * Push page with info about the different ways to play the game.
         */
        private void PlayerOptionsButton_Clicked(object sender, System.EventArgs e)
        {
            //TODO
        }

        /**
         * Push page with further info/cards about different types of biases.
         */
        private void BiasesPageButton_Clicked(object sender, System.EventArgs e)
        {
            //TODO
        }

        /**
         * Push settings page.
         */
        private void SettingsButton_Clicked(object sender, System.EventArgs e)
        {
            //TODO
        }

        /**
         * Push help page.
         */
        private void HelpButton_Clicked(object sender, System.EventArgs e)
        {
            //TODO
        }
    }
}