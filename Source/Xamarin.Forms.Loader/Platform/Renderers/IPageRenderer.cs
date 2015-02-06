using Xamarin.Forms.Platform.Controllers;

namespace Xamarin.Forms.Platform.Renderers {

    public interface IPageRenderer<TElement, out TControl> :
        IVisualElementRenderer<TElement, TControl, VisualElementController>
        where TElement : Page { }
}