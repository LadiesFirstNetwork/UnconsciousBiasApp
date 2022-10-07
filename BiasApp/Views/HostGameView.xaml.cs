using BiasApp.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HostGameView : ContentPage
    {
        private FlyoutPage main;
        private Page previousPage;
        private CardViewModel cardViewModel;
        private List<string> selectedList;
        private List<string> categories;

        public HostGameView(Page previous)
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


        // Get error message
        public string GetMessage(int count, string hostName)
        {
            string message = string.Empty;

            if (string.IsNullOrEmpty(hostName) && count == 0)
            {
                message = "Skriv venligst et navn, vælg minimum ét dæk at spille med og prøv igen.";
            }
            else if (string.IsNullOrEmpty(hostName))
            {
                message = "Skriv venligst et navn og prøv igen.";
            }
            else if (count == 0)
            {
                message = "Vælg venligst minimum ét dæk at spille med og prøv igen.";
            }

            return message;
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

        private async void FindPlayersButton_Clicked(object sender, EventArgs e)
        {
            refreshView.IsRefreshing = true;
            string hostName = entryName.Text;
            int count = selectedList.Count;
            string title = "Information";

            if (string.IsNullOrEmpty(hostName) || count == 0)
            {
                await DisplayAlert(title, GetMessage(count, hostName), "OK");
                return;
            }

            entryName.IsReadOnly = true;
            // TODO: Disable checkboxes in catColView
            FindPlayersBtn.IsEnabled = false;


            //TODO: Put game out there for other players to see and join.



            WaitLbl.IsVisible = true;
            emptyView.IsVisible = true;

            // TODO: Fill CollectionView with connected devices.
            List<string> connectedNames = new List<string>();


            HostCollectionView.ItemsSource = connectedNames;

            if (HostCollectionView.ItemsSource != null)
            {
                StartBtn.IsEnabled = true;
            }

            refreshView.IsRefreshing = false;
        }

        private void StartGameButton_Clicked(object sender, EventArgs e)
        {
            // TODO: Setup game


            // TODO: Direct to MultiplayerGamePage and pass needed data (including players).
            main.Detail = new NavigationPage(new MultiplayerGameView(selectedList));
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            main.Detail = previousPage;
        }
    }
}