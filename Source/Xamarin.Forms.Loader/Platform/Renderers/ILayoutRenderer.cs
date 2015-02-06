using Xamarin.Forms.Platform.Controllers;

namespace Xamarin.Forms.Platform.Renderers {

    public interface ILayoutRenderer<TElement, out TControl> :
        IViewRenderer<TElement, TControl, ViewController>
        where TElement : Layout { }
}