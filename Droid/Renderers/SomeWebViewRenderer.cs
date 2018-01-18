using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.Collections.Generic;
using Android.Views;
using WebViewRenderer.Droid.Renderers;

[assembly: ExportRenderer (typeof(WebView), typeof(SomeWebViewRenderer))]
namespace WebViewRenderer.Droid.Renderers
{
    public class SomeWebViewRenderer : ViewRenderer<WebView, Android.Webkit.WebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                ["A-custom-header"] = "a custom value"
            };

            Android.Webkit.WebView webView = Control as Android.Webkit.WebView;

            if (Control == null) {
                webView = new Android.Webkit.WebView(Forms.Context);
                SetNativeControl(webView);
            }

            webView.Settings.JavaScriptEnabled = true;

            webView.Settings.BuiltInZoomControls = true;
            webView.Settings.SetSupportZoom(true);

            webView.ScrollBarStyle = ScrollbarStyles.OutsideOverlay;
            webView.ScrollbarFadingEnabled = false;

            webView.SetWebViewClient(new SomeWebViewClient(headers));
            UrlWebViewSource source = Element.Source as UrlWebViewSource;
            webView.LoadUrl(source.Url, headers);
        }
    }

    public class SomeWebViewClient : Android.Webkit.WebViewClient
    {
        public Dictionary<string, string> headers { get; set; }

        public SomeWebViewClient(Dictionary<string, string> requestHeaders)
        {
            headers = requestHeaders;
        }

        public override bool ShouldOverrideUrlLoading(Android.Webkit.WebView View, string url)
        {
            View.LoadUrl(url, headers);
            return true;
        }

        public override void OnPageStarted(Android.Webkit.WebView view, string url, Android.Graphics.Bitmap favicon)
        {
            base.OnPageStarted(view, url, favicon);
            System.Diagnostics.Debug.WriteLine("Loading website...");
        }

        public override void OnPageFinished(Android.Webkit.WebView view, string url)
        {
            base.OnPageFinished(view, url);
            System.Diagnostics.Debug.WriteLine("Load finished.");
        }

        public override void OnReceivedError(Android.Webkit.WebView view, Android.Webkit.ClientError errorCode, string description, string failingUrl)
        {
            base.OnReceivedError(view, errorCode, description, failingUrl);
        }
    }
}


