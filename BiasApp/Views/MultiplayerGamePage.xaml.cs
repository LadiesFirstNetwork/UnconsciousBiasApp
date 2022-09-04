using BiasApp.Models;
using BiasApp.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MvvmHelpers;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultiplayerGamePage : ContentPage
    {
        private FlyoutPage main;
        private CardViewModel cardViewModel;

        public MultiplayerGamePage(List<string> categories)
        {
            InitializeComponent();

            main = Application.Current.MainPage as FlyoutPage;
            cardViewModel = new CardViewModel();

            ObservableRangeCollection<SituationCard> Cards = cardViewModel.GetSituationCardsByCategories(categories);
            // TODO: x.ItemsSource = Cards;
        }

        private void BackButton_Clicked(object sender, System.EventArgs e)
        {
            Page home = new NavigationPage(new HomePage());
            Page returnPage = new NavigationPage(new GameMainMenuPage(home));
            main.Detail = new NavigationPage(new HostGamePage(returnPage));
        }
    }
}