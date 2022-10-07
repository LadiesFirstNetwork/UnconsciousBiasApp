using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JoinGameView : ContentPage
    {
        private FlyoutPage main;
        private Page previousPage;

        public JoinGameView(Page previous)
        {
            InitializeComponent();

            main = Application.Current.MainPage as FlyoutPage;
            previousPage = previous;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            main.Detail = previousPage;
        }
    }
}