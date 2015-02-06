using Xamarin.Forms.Platform.Controllers;

namespace Xamarin.Forms.Platform.Renderers {

    public interface IButtonRenderer<TElement, out TControl> :
        IViewRenderer<TElement, TControl, ButtonController>
        where TElement : Button { }
}