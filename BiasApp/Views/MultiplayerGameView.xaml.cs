using BiasApp.Models;
using BiasApp.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultiplayerGameView : ContentPage
    {
        private FlyoutPage main;
        private CardViewModel cardViewModel;

        public MultiplayerGameView(List<string> categories)
        {
            InitializeComponent();

            main = Application.Current.MainPage as FlyoutPage;
            cardViewModel = new CardViewModel();

            ObservableCollection<SituationCard> Cards = cardViewModel.GetSituationCardsByCategories(categories);
            // TODO: x.ItemsSource = Cards;
        }

        private void BackButton_Clicked(object sender, System.EventArgs e)
        {
            Page home = new NavigationPage(new HomeView());
            Page returnPage = new NavigationPage(new GameMainView(home));
            main.Detail = new NavigationPage(new HostGameView(returnPage));
        }
    }
}