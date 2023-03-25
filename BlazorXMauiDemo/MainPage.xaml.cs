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
                // Sometimes this cast does not work... Can be ignored anyway, just a little less user friendly
                (blazorWebView.Handler.PlatformView as Microsoft.UI.Xaml.Controls.WebView2).CoreWebView2.Settings
                    .IsGeneralAutofillEnabled = false;
            }   
            catch (Exception)
            {
            }
    #endif  
        }
    }
}