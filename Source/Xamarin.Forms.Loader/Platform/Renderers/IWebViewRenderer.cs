using Xamarin.Forms.Platform.Controllers;

namespace Xamarin.Forms.Platform.Renderers {

    public interface IWebViewRenderer<TElement, out TControl> :
        IViewRenderer<TElement, TControl, WebViewController>
        where TElement : WebView { }
}