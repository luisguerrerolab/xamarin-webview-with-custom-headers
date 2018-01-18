//using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Foundation;
using UIKit;
using WebViewRenderer.iOS.Renderers;

[assembly: ExportRenderer(typeof(WebView), typeof(SomeWebViewRenderer))]
namespace WebViewRenderer.iOS.Renderers
{
    public class SomeWebViewRenderer : ViewRenderer<WebView, UIWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            var webView = Control as UIWebView;

            if (webView == null) {
                webView = new UIWebView();
                SetNativeControl(webView);
            }

            webView.ScalesPageToFit = true;

            webView.LoadStarted += (object sender, System.EventArgs evtArgs) => {
                System.Diagnostics.Debug.WriteLine("Loading...");
            };

            webView.LoadFinished += (object sender, System.EventArgs evtArgs) => {
                System.Diagnostics.Debug.WriteLine("Load finished.");
            };

            if (e.NewElement != null) {
                UrlWebViewSource source = (Xamarin.Forms.UrlWebViewSource)Element.Source;
                var webRequest = new NSMutableUrlRequest(new NSUrl(source.Url));
                var headerKey = new NSString("A-custom-header");
                var headerValue = new NSString("a custom value");
                var dictionary = new NSDictionary(headerKey, headerValue);

                webRequest.Headers = dictionary;

                this.Control.LoadRequest(webRequest);
            }

        }
    }
}

