using System;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPopupView : Popup
    {
        public Page PreviousView { get; set; }
        public GameMainView GameMain { get; set; }
        public CreateSingleplayerView CreateSingleplayer { get; set; }
        public BiasInfoView BiasInfo { get; set; }
        public HomeView Home { get; set; }

        public MenuPopupView(Page previous)
        {
            InitializeComponent();
            PreviousView = previous;
        }

        /**
         * Return view with multiplayer options.
         */
        private void MultiplayerButton_Clicked(object sender, EventArgs e)
        {
            if (GameMain is null)
            {
                GameMain = new GameMainView(PreviousView);
            }

            Dismiss(GameMain);
        }

        /**
         * Return view with singleplayer options.
         */
        private void SingleplayerButton_Clicked(object sender, EventArgs e)
        {
            if (CreateSingleplayer is null)
            {
                CreateSingleplayer = new CreateSingleplayerView(PreviousView);
            }

            Dismiss(CreateSingleplayer);
        }

        /**
         * Return view with bias info cards.
         */
        private void BiasInfoButton_Clicked(object sender, EventArgs e)
        {
            if (BiasInfo is null)
            {
                BiasInfo = new BiasInfoView(PreviousView);
            }

            Dismiss(BiasInfo);
        }

        /**
         * Return view with step-by-step-guide.
         */
        private void GameGuideButton_Clicked(object sender, EventArgs e)
        {
            //TODO: Implement Step-By-Step Guide and Navigate to it.
            if (Home is null)
            {
                Home = new HomeView();
            }

            Dismiss(Home);
        }

        /**
         * Return view with settings.
         */
        private void SettingsButton_Clicked(object sender, EventArgs e)
        {
            //TODO: Implement Settings and Navigate to it.
            if (Home is null)
            {
                Home = new HomeView();
            }

            Dismiss(Home);
        }

        /**
         * Return view with user support.
         */
        private void HelpButton_Clicked(object sender, EventArgs e)
        {
            //TODO: Implement Support page and Navigate to it.

            if (Home is null)
            {
                Home = new HomeView();
            }

            Dismiss(Home);
        }

        /**
         * Close popup.
         */
        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }
    }
}