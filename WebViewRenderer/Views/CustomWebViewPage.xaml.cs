using System;
using Xamarin.Forms;

namespace WebViewRenderer
{
    public partial class CustomWebViewPage : ContentPage
    {
        public CustomWebViewPage()
        {
            InitializeComponent();
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();

            hola.CustomHeaderValue = "header reset";
		}
	}
}
