using System;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPopup : Popup
    {
        private Page previousPage;
        private GameMainMenuPage gameMain = null;
        private BiasInfoPage biasInfo = null;

        public MenuPopup(Page previous)
        {
            InitializeComponent();

            previousPage = previous;

            IsLightDismissEnabled = true;
        }

        /**
         * Push view with different playing options. 
         * Playing with all cards or one specific category of cards.
         */
        private void PlayPageButton_Clicked(object sender, EventArgs e)
        {
            if (gameMain == null)
            {
                gameMain = new GameMainMenuPage();
            }

            Dismiss(gameMain);
        }

        /**
         * Return PlayerOptionsPage to MainPage.
         */
        private void PlayerOptionsButton_Clicked(object sender, EventArgs e)
        {
            //TODO
        }

        /**
         * Return BiasInfoPage to MainPage.
         */
        private void BiasesPageButton_Clicked(object sender, EventArgs e)
        {
            if (biasInfo == null)
            {
                biasInfo = new BiasInfoPage(previousPage);
            }

            Dismiss(biasInfo);
        }

        /**
         * Return SettingsPage to MainPage.
         */
        private void SettingsButton_Clicked(object sender, EventArgs e)
        {
            //TODO
        }

        /**
         * Return HelpPage to MainPage.
         */
        private void HelpButton_Clicked(object sender, EventArgs e)
        {
            //TODO
        }
    }
}