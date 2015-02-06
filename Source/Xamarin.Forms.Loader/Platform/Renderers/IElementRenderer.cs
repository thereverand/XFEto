using System.Reflection;
using Xamarin.Forms;

namespace Xamarin.Forms.Platform.Renderers {

    public interface IElementRenderer<TElement, out TView, out TController> :
        IHandler<TView>
        where TController : IElementController
        where TElement : Element {

        TElement Element { get; set; }

        TController Controller { get; }
    }
}