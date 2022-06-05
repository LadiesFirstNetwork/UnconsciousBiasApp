using System;
using BiasApp.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateSinglePlayerGamePage : ContentPage
    {
        private FlyoutPage main;
        private Page previousPage;
        private CardViewModel cardViewModel;
        private List<string> selectedList;
        private List<string> categories;

        public CreateSinglePlayerGamePage(Page previous)
        {
            InitializeComponent();

            main = Application.Current.MainPage as FlyoutPage;
            previousPage = previous;
            cardViewModel = new CardViewModel();
            selectedList = new List<string>();

            // Get list of categories
            categories = cardViewModel.GetCategories();

            // Fill CollectionView with categories
            catColView.ItemsSource = categories;
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            string category = checkBox.BindingContext.ToString();

            if (e.Value == true)
            {
                if (!selectedList.Contains(category))
                {
                    selectedList.Add(category);
                }
            }
            else
            {
                if (selectedList.Contains(category))
                {
                    selectedList.Remove(category);
                }
            }
        }

        private async void StartGameButton_Clicked(object sender, EventArgs e)
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                if (selectedList.Count == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Information", "Vælg venligst minimum ét dæk at spille med og prøv igen.", "OK");
                    return;
                }
                else if (selectedList.Contains(categories[0]))
                {
                    main.Detail = new NavigationPage(new SinglePlayerGamePage(categories));
                }
                else
                {
                    main.Detail = new NavigationPage(new SinglePlayerGamePage(selectedList));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to start single player game: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", "Unable to start game. Update app and try again.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            main.Detail = previousPage;
        }
    }
}