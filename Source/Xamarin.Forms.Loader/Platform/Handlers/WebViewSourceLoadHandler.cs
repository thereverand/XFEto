namespace Xamarin.Forms.Platform.Handlers {

    public abstract class WebViewSourceLoadHandler : IWebViewRenderer {

        public abstract void LoadUrl(string url);

        public abstract void LoadHtml(string html, string baseUrl);
    }
}