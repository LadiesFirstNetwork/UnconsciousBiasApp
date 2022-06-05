using Foundation;
using System;
using TestFairyLib;
using UIKit;

namespace BiasApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Invoke TestFairy begin to start session recording
            //TestFairy.Begin("SDK - Uq2zLo9O");

            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.Forms.FormsMaterial.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        /// <summary>
        /// TestFairy Remote Logging.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        //public static void Log(string format, params object[] arg)
        //{
        //    using (var nsFormat = new NSString(string.Format(format, arg)))
        //    {
        //        CFunctions.TFLog(nsFormat.Handle, ""); Console.WriteLine(string.Format(format, arg));
        //    }
        //}
    }
}
