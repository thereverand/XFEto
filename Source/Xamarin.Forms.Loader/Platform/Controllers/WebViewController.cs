using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.Handlers;
using Xamarin.Forms.Platform.Renderers;

namespace Xamarin.Forms.Platform.Controllers {

    public class WebViewController : ViewController {

        public static WebViewController ForWebView(WebView view) {
            return new WebViewController(view);
        }

        protected WebView View { get; set; }

        internal WebViewController(WebView view)
            : base(view) {
            View = view;
        }

        public void LoadSource(WebViewSourceLoadHandler handler) {
            View.Source.Load(handler);
        }
    }
}