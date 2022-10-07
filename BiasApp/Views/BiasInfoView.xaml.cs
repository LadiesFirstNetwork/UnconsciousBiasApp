using BiasApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BiasInfoView : ContentPage
    {
        private FlyoutPage Main;
        private Page PreviousView;
        public CardViewModel ViewModel { get; set; }

        public BiasInfoView(Page previous)
        {
            InitializeComponent();
            Main = Application.Current.MainPage as FlyoutPage;
            PreviousView = previous;
            ViewModel = new CardViewModel();
            BindingContext = ViewModel;
            View.ItemsSource = ViewModel.BiasCards;
        }

        // Turn card from frontside to backside
        private async void FlipToBackAsync(object sender, EventArgs e)
        {
            var front = sender as Grid;
            var back = front.Parent.FindByName<Grid>("BackView");
            await ViewModel.Flip(front, back);
        }

        // Turn card from backside to frontside
        private async void FlipToFrontAsync(object sender, EventArgs e)
        {
            var back = sender as Grid;
            var front = back.Parent.FindByName<Grid>("FrontView");
            await ViewModel.Flip(back, front);
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Main.Detail = PreviousView;
        }
    }
}