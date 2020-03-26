# :warning: This repo uses `UIWebView` but it has been deprecated. As of April 2020, Apple announced they will reject new apps still referencing it. — [UIWebView Deprecation and Xamarin.Forms - Xamarin Blog](https://devblogs.microsoft.com/xamarin/uiwebview-deprecation-xamarin-forms/)


# Xamarin WebView With Custom Headers

An example that shows how to send request headers in a Xamarin Webview using custom renderers. An example that shows how define custom headers values from shared code is also included.

## Simple version

The request is filled with a custom header which then can be fetched in the website scanning the request's headers:


### Android

Android requires the `INTERNET` permission in order to load a website from the Internet.

Basically, you need to define a `WebViewClient` and override the `ShouldOverrideUrlLoading(WebView view, string url)` function, then set the headers and perform the request calling `View.LoadUrl(url, headers)`.


### iOS

iOS doesn't require any special configuration.

```
var headerKey = new NSString("A-custom-header");
var headerValue = new NSString("a custom value");
var dictionary = new NSDictionary(headerKey, headerValue);

webRequest.Headers = dictionary;
```


## Defining custom headers values from shared code

If you want to assign a custom value from shared code to each renderer, take a look at the `CustomWebView` control and `CustomWebViewPage` view to see how to achieve this. Basically, we're using Xamarin.Forms custom controls and data bindings to define custom parameters and get the value in each custom renderer.


## References

[Xamarin WebView Guide](https://developer.xamarin.com/guides/xamarin-forms/user-interface/webview/)

[My discussion in Xamarin Forums](https://forums.xamarin.com/discussion/57284/it-is-possible-to-send-headers-when-calling-a-webview)


## Build Information

This project was created in **Visual Studio for Mac**

Versión: 7.3.3 (build 5)

Template: Xamarin Forms App
