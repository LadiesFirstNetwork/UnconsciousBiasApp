using BiasApp.Models;
using BiasApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class SingleplayerGameView : ContentPage
    {
        private FlyoutPage main;
        private CardViewModel cardViewModel;

        public SingleplayerGameView(List<string> categories)
        {
            InitializeComponent();

            main = Application.Current.MainPage as FlyoutPage;
            cardViewModel = new CardViewModel();

            ObservableCollection<SituationCard> Cards = cardViewModel.GetSituationCardsByCategories(categories);
            SinglePlayerCarouselView.ItemsSource = Cards;
        }

        // Turn card from frontside to backside
        private async void FlipToBack(object sender, EventArgs e)
        {
            var front = sender as Grid;
            var back = front.Parent.FindByName<Grid>("BackView");
            await cardViewModel.Flip(front, back);
        }

        // Turn card from backside to frontside
        private async void FlipToFront(object sender, EventArgs e)
        {
            var back = sender as Grid;
            var front = back.Parent.FindByName<Grid>("FrontView");
            await cardViewModel.Flip(back, front);
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Page returnPage = new NavigationPage(new HomeView());
            main.Detail = new NavigationPage(new CreateSingleplayerView(returnPage));
        }
    }
}