using System;

using Xamarin.Forms;

namespace WebViewRenderer
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public App()
        {
            InitializeComponent();

            //if (Device.RuntimePlatform == Device.iOS)
            //    MainPage = new SomeWebViewPage();
            //else
                MainPage = new NavigationPage(new SomeWebViewPage());
        }
    }
}
