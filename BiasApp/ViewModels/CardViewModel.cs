using BiasApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using MvvmHelpers;
using System.Threading.Tasks;

namespace BiasApp.ViewModels
{
    public class CardViewModel : BaseViewModel
    {
        public ObservableRangeCollection<SituationCard> SituationCards;
        public ObservableRangeCollection<BiasCard> BiasCards;
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
            await from.RotateYTo(-90, 300, Easing.SpringIn);
            to.RotationY = 90;
            to.IsVisible = true;
            from.IsVisible = false;
            await to.RotateYTo(0, 300, Easing.SpringOut);
        }

        // Get situation cards with specific category or categories.
        public ObservableRangeCollection<SituationCard> GetSituationCardsByCategories(List<string> categories)
        {
            ObservableRangeCollection<SituationCard> cardsToReturn = new ObservableRangeCollection<SituationCard>();

            ObservableRangeCollection<SituationCard> allCards = GetSituationCards();

            foreach (string cat in categories)
            {
                cardsToReturn.AddRange(allCards.Where(c => c.Category == cat).ToList());
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
        public ObservableRangeCollection<SituationCard> GetSituationCards()
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
                return new ObservableRangeCollection<SituationCard>();
            }
            finally
            {
                IsBusy = false;
            }
        }

        // Get all bias cards.
        public ObservableRangeCollection<BiasCard> GetBiasCards()
        {
            if (IsBusy)
            {
                return null;
            }

            try
            {
                IsBusy = true;

                return Storage.Storage.GetInstance().BiasCards;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get list of bias cards: {ex}");
                Application.Current.MainPage.DisplayAlert("Error!", "Unable to get list of bias cards. Update app and try again.", "OK");
                return new ObservableRangeCollection<BiasCard>();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
