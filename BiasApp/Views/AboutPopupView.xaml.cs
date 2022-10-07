using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms.Xaml;

namespace BiasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPopupView : Popup
    {
        public AboutPopupView()
        {
            InitializeComponent();
        }

        private void CloseButton_Clicked(object sender, System.EventArgs e)
        {
            Dismiss(null);
        }
    }
}