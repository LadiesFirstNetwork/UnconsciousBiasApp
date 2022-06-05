using System;
using BiasApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BiasInfoPage : ContentPage
    {
        private FlyoutPage main;
        private Page previousPage;
        private CardViewModel viewModel;

        public BiasInfoPage(Page previous)
        {
            InitializeComponent();

            main = Application.Current.MainPage as FlyoutPage;
            previousPage = previous;
            viewModel = new CardViewModel();

            BindingContext = viewModel;
            View.ItemsSource = viewModel.BiasCards;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            main.Detail = previousPage;
        }
    }
}