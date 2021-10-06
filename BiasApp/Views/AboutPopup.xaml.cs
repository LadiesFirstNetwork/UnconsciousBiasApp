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
        }

        /**
         * Push new page with information about this app.
         */
        private void AboutAppButton_Clicked(object sender, System.EventArgs e)
        {
            //TODO
        }

        /**
         * Push new page with information on Ladies First.
         */
        private void AboutLadiesFirstButton_Clicked(object sender, System.EventArgs e)
        {
            //TODO
        }

        /**
         * Push new page with contact information.
         */
        private void ContactButton_Clicked(object sender, System.EventArgs e)
        {
            //TODO
        }

        /**
         * Push new page with privacy policy information.
         */
        private void PrivacyPolicyButton_Clicked(object sender, System.EventArgs e)
        {
            //TODO
        }

        /**
         * Push new page with license information.
         */
        private void LicenseButton_Clicked(object sender, System.EventArgs e)
        {
            //TODO
        }
    }
}