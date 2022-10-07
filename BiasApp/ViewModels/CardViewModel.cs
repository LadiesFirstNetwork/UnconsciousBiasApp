using BiasApp.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BiasApp.ViewModels
{
    public class CardViewModel : BaseViewModel
    {
        public ObservableCollection<SituationCard> SituationCards;
        public ObservableCollection<BiasCard> BiasCards;
        public List<string> Categories;

        public CardViewModel()
        {
            SituationCards = GetSituationCards();
            BiasCards = GetBiasCards();
            Categories = GetCategories();
        }

        // Draw card animation.
        public async Task Draw(VisualElement from, VisualElement to)
        {
            await from.RotateXTo(90, 200, Easing.SpringOut);
            to.RotationX = -90;
            to.IsVisible = true;
            from.IsVisible = false;
            await to.RotateXTo(0, 200, Easing.SpringIn);
        }

        // Turn card animation.
        public async Task Flip(VisualElement from, VisualElement to)
        {
            await from.RotateYTo(-90, 500, Easing.SpringIn); //300
            to.RotationY = 90;
            to.IsVisible = true;
            from.IsVisible = false;
            await to.RotateYTo(0, 500, Easing.SpringOut);
        }

        // Get situation cards with specific category or categories.
        public ObservableCollection<SituationCard> GetSituationCardsByCategories(List<string> categories)
        {
            ObservableCollection<SituationCard> cardsToReturn = new ObservableCollection<SituationCard>();

            ObservableCollection<SituationCard> allCards = GetSituationCards();

            foreach (string cat in categories)
            {
                foreach (var card in allCards)
                {
                    if (card.Category == cat)
                    {
                        cardsToReturn.Add(card);
                    }
                }
            }

            return cardsToReturn;
        }

        // Get all categories from situation cards.
        public List<string> GetCategories()
        {
            List<string> categories = new List<string>();

            categories.Add("Alle dæk");

            for (int i = 0; i < SituationCards.Count; i++)
            {
                try
                {
                    string category = SituationCards[i].Category.Trim();

                    if (!categories.Contains(category))
                    {
                        categories.Add(category);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Unable to make list of situation card categories: {ex.Message}");
                    Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
                }
            }

            return categories;
        }

        // Get all situation cards.
        public ObservableCollection<SituationCard> GetSituationCards()
        {
            if (IsBusy)
            {
                return null;
            }

            try
            {
                IsBusy = true;

                return Storage.Storage.GetInstance().SituationCards;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get list of situation cards: {ex}");
                Application.Current.MainPage.DisplayAlert("Error!", "Unable to get list of situation cards. Update app and try again.", "OK");
                return new ObservableCollection<SituationCard>();
            }
            finally
            {
                IsBusy = false;
            }
        }

        // Get all bias cards.
        public ObservableCollection<BiasCard> GetBiasCards()
        {
            if (IsBusy)
            {
                return null;
            }

            try
            {
                IsBusy = true;

                var s = Storage.Storage.GetInstance();
                Task.Run(async () => await s.GetBiasCardsAsync());
                return s.BiasCards;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get list of bias cards: {ex}");
                Application.Current.MainPage.DisplayAlert("Error!", "Unable to get list of bias cards. Update app and try again.", "OK");
                return new ObservableCollection<BiasCard>();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
