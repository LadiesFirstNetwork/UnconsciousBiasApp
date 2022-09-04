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
        private GameMainMenuPage multi = null;
        private CreateSinglePlayerGamePage single = null;
        private BiasInfoPage biasInfo = null;

        public MenuPopup(Page previous)
        {
            InitializeComponent();

            previousPage = previous;
        }

        /**
         * Push view with different playing options. 
         * Playing with all cards or one specific category of cards.
         */
        private void PlayMultiplayerPageButton_Clicked(object sender, EventArgs e)
        {
            if (multi is null)
            {
                multi = new GameMainMenuPage(previousPage);
            }

            Dismiss(multi);
        }

        /**
         * Return CreateSinglePlayerPage to MainPage.
         */
        private void PlaySingleplayerPageButton_Clicked(object sender, EventArgs e)
        {
            if (single is null)
            {
                single = new CreateSinglePlayerGamePage(previousPage);
            }

            Dismiss(single);
        }

        /**
         * Return BiasInfoPage to MainPage.
         */
        private void BiasesPageButton_Clicked(object sender, EventArgs e)
        {
            if (biasInfo is null)
            {
                biasInfo = new BiasInfoPage(previousPage);
            }

            Dismiss(biasInfo);
        }

        /**
         * Return HowToGamePage to MainPage.
         */
        private void GameGuideButton_Clicked(object sender, EventArgs e)
        {
            //TODO
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

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }
    }
}