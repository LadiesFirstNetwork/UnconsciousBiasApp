using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameMainView : ContentPage
    {
        private FlyoutPage main;
        private Page previousPage;
        private Page current;

        public GameMainView(Page previous)
        {
            InitializeComponent();

            main = Application.Current.MainPage as FlyoutPage;
            previousPage = previous;
        }

        private void HostGameButton_Clicked(object sender, EventArgs e)
        {
            current = main.Detail;
            main.Detail = new NavigationPage(new HostGameView(current));
        }

        private void JoinGameButton_Clicked(object sender, EventArgs e)
        {
            current = main.Detail;
            main.Detail = new NavigationPage(new JoinGameView(current));
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            main.Detail = previousPage;
        }
    }
}