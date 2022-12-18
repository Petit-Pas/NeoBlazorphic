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
            (blazorWebView.Handler.PlatformView as Microsoft.UI.Xaml.Controls.WebView2).CoreWebView2.Settings.IsGeneralAutofillEnabled = false;
    #endif
        }
    }
}