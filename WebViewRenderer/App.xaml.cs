using System;

using Xamarin.Forms;

namespace WebViewRenderer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FormsWebViewPage());
        }
    }
}
