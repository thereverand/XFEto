using Xamarin.Forms.Platform.Controllers;

namespace Xamarin.Forms.Platform.Renderers {

    public interface ICellRenderer<TElement, out TControl> :
        IElementRenderer<TElement, TControl, ElementController>
        where TElement : Cell { }
}