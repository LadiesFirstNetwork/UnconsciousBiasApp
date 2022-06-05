using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPopup : Popup
    {
        public AboutPopup()
        {
            InitializeComponent();

            IsLightDismissEnabled = true;
        }
    }
}