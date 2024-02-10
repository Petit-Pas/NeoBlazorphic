using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Web.WebView2.Core;

namespace BlazorXMauiDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Loaded += MainPage_Loaded;
            InitializeComponent();
        }

        private void MainPage_Loaded(object sender, EventArgs e)
        {
#if WINDOWS
            try
            {
                var webView2 = blazorWebView.Handler.PlatformView as Microsoft.UI.Xaml.Controls.WebView2;
                webView2.NavigationCompleted += WebView2_NavigationCompleted;
            }
            catch (Exception)
            {
            }
#endif

//#if WINDOWS
//            try
//            {   
//                // Sometimes this cast does not work... Can be ignored anyway, just a little less user friendly
//                (blazorWebView.Handler.PlatformView as Microsoft.UI.Xaml.Controls.WebView2).CoreWebView2.Settings
//                    .IsGeneralAutofillEnabled = false;
//                var version = (blazorWebView.Handler.PlatformView as Microsoft.UI.Xaml.Controls.WebView2).CoreWebView2.Environment.BrowserVersionString;
//            }
//            catch (Exception)
//            {
//            }
//    #endif  
        }

        private void WebView2_NavigationCompleted(Microsoft.UI.Xaml.Controls.WebView2 sender, object args)
        {
            sender.CoreWebView2.Settings.IsGeneralAutofillEnabled = false;
            var version = sender.CoreWebView2.Environment.BrowserVersionString;
        }
    }
}