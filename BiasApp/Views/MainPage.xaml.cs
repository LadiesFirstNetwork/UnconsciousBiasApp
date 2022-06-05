using BiasApp.Models;
using BiasApp.Views;
using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();

            flyout.listview.ItemSelected += OnSelectedItem;
        }

        private async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;

            if (item != null)
            {
                if (item.TargetPage.Name.Contains("Popup"))
                {
                    Page current = Detail;

                    flyout.listview.SelectedItem = null;
                    IsPresented = false;

                    object objReturned = null;

                    if (item.TargetPage.Name.EndsWith("MenuPopup"))
                    {
                        objReturned = await current.Navigation.ShowPopupAsync(new MenuPopup(current));
                    }
                    else if (item.TargetPage.Name.EndsWith("AboutPopup"))
                    {
                        objReturned = await current.Navigation.ShowPopupAsync(new AboutPopup());
                    }

                    if (objReturned != null)
                    {
                        Detail = new NavigationPage((Page)objReturned);
                    }
                }
                else
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                }

                flyout.listview.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}