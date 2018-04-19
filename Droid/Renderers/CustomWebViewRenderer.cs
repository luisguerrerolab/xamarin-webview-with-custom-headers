using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.Collections.Generic;
using Android.Views;
using WebViewRenderer.Droid.Renderers;
using WebViewRenderer.Controls;
using Android.Content;
using Android.Webkit;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace WebViewRenderer.Droid.Renderers
{
    public class CustomWebViewRenderer : ViewRenderer<CustomWebView, Android.Webkit.WebView>
    {
        Android.Content.Context _localContext;
        public CustomWebViewRenderer(Context context) : base(context)
        {
            _localContext = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomWebView> e)
        {
            base.OnElementChanged(e);

            Android.Webkit.WebView webView = Control as Android.Webkit.WebView;

            if (Control == null) {
                webView = new Android.Webkit.WebView(_localContext);
                SetNativeControl(webView);
            }

            if (e.OldElement != null) {
                // ...
            }

            if (e.NewElement != null) {
				Dictionary<string, string> headers = new Dictionary<string, string> {
					["A-custom-header"] = Element.CustomHeaderValue
				};
				
				webView.Settings.JavaScriptEnabled = true;
				
				webView.Settings.BuiltInZoomControls = true;
				webView.Settings.SetSupportZoom(true);
				
				webView.ScrollBarStyle = ScrollbarStyles.OutsideOverlay;
				webView.ScrollbarFadingEnabled = false;
				
				webView.SetWebViewClient(new CustomWebViewClient(headers));
				UrlWebViewSource source = Element.Source as UrlWebViewSource;
				webView.LoadUrl(source.Url, headers);
            }
        }
    }

    public class CustomWebViewClient : Android.Webkit.WebViewClient
    {
        public Dictionary<string, string> headers { get; set; }

        public CustomWebViewClient(Dictionary<string, string> requestHeaders)
        {
            headers = requestHeaders;
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

        public override void OnReceivedError(Android.Webkit.WebView view, IWebResourceRequest request, WebResourceError error)
        {
            base.OnReceivedError(view, request, error);
        }
	}
}


