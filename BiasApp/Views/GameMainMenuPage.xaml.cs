using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameMainMenuPage : ContentPage
    {
        private FlyoutPage main;
        private Page current;

        public GameMainMenuPage()
        {
            InitializeComponent();

            main = Application.Current.MainPage as FlyoutPage;
        }

        private void HostGameButton_Clicked(object sender, EventArgs e)
        {
            current = main.Detail;
            main.Detail = new NavigationPage(new HostGamePage(current));
        }

        private void JoinGameButton_Clicked(object sender, EventArgs e)
        {
            current = main.Detail;
            main.Detail = new NavigationPage(new JoinGamePage(current));
        }

        private void SinglePlayerButton_Clicked(object sender, EventArgs e)
        {
            current = main.Detail;
            main.Detail = new NavigationPage(new CreateSinglePlayerGamePage(current));
        }
    }
}