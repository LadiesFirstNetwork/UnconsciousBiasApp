using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private FlyoutPage main;
        private Page current;

        public HomePage()
        {
            InitializeComponent();
        }

        private void SinglePlayerButton_Clicked(object sender, EventArgs e)
        {
            main = Application.Current.MainPage as FlyoutPage;
            current = main.Detail;
            main.Detail = new NavigationPage(new CreateSinglePlayerGamePage(current));
        }

        private void MultiPlayerButton_Clicked(object sender, System.EventArgs e)
        {
            main = Application.Current.MainPage as FlyoutPage;
            current = main.Detail;
            main.Detail = new NavigationPage(new GameMainMenuPage(current));
        }
    }
}