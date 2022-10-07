using BiasApp.Controls;
using BiasApp.Views;
using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiasApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : FlyoutPage
    {
        public MainView()
        {
            InitializeComponent();

            flyout.listview.ItemSelected += OnSelectedItem;
        }

        private async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MyFlyoutItem;

            if (item is MyFlyoutItem flyoutItem)
            {
                Page current = Detail;
                object objReturned = null;
                flyout.listview.SelectedItem = null;
                IsPresented = false;

                switch (item.TargetPage.Name)
                {
                    case nameof(HomeView):
                        Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                        break;

                    case nameof(MenuPopupView):
                        objReturned = await current.Navigation.ShowPopupAsync(new MenuPopupView(current));

                        if (objReturned != null)
                        {
                            Detail = new NavigationPage((Page)objReturned);
                        }
                        break;

                    case nameof(AboutPopupView):
                        objReturned = await current.Navigation.ShowPopupAsync(new AboutPopupView());

                        if (objReturned != null)
                        {
                            Detail = new NavigationPage((Page)objReturned);
                        }
                        break;
                }
            }
        }
    }
}