namespace Xamarin.Forms.Platform.Renderers {

    public interface IViewRenderer<TElement, out TControl, out TController> :
        IVisualElementRenderer<TElement, TControl, TController>
        where TElement : View
        where TController : IViewController { }
}