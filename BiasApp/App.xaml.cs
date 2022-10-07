using Xamarin.Forms;

namespace BiasApp
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { "MediaElement_Experimental" });

            InitializeComponent();

            MainPage = new MainView();
        }

        protected override void OnStart()
        {
            base.OnStart();
            Storage.Storage.GetInstance();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
