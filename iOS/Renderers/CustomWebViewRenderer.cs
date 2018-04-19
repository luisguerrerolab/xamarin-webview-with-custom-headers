using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Foundation;
using UIKit;
using WebViewRenderer.iOS.Renderers;
using WebViewRenderer.Controls;
using System;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace WebViewRenderer.iOS.Renderers
{
    public class CustomWebViewRenderer : ViewRenderer<CustomWebView, UIWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomWebView> e)
        {
            base.OnElementChanged(e);

            EventHandler loadHandler = (s, evtArgs) => System.Diagnostics.Debug.WriteLine("Load finished.");

            var webView = Control as UIWebView;

            if (webView == null) {
                webView = new UIWebView();
                webView.ScalesPageToFit = true;
                SetNativeControl(webView);
            }

            if (e.OldElement != null) {
                webView.LoadFinished -= loadHandler;
            }

            if (e.NewElement != null) {
                webView.LoadFinished += loadHandler;

				var headerKey = new NSString("A-custom-header");
				var headerValue = new NSString(Element.CustomHeaderValue);
				var dictionary = new NSDictionary(headerKey, headerValue);

                UrlWebViewSource source = (Xamarin.Forms.UrlWebViewSource)Element.Source;
                var webRequest = new NSMutableUrlRequest(new NSUrl(source.Url));
                webRequest.Headers = dictionary;

                Control.LoadRequest(webRequest);
            }

        }
    }
}

