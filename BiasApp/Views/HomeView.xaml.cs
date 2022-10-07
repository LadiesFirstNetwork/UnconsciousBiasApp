using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        private FlyoutPage main;
        private Page current;

        public HomeView()
        {
            InitializeComponent();
        }

        private void SingleplayerButton_Clicked(object sender, EventArgs e)
        {
            main = Application.Current.MainPage as FlyoutPage;
            current = main.Detail;
            main.Detail = new NavigationPage(new CreateSingleplayerView(current));
        }

        private void MultiplayerButton_Clicked(object sender, System.EventArgs e)
        {
            main = Application.Current.MainPage as FlyoutPage;
            current = main.Detail;
            main.Detail = new NavigationPage(new GameMainView(current));
        }
    }
}