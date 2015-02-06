namespace Xamarin.Forms.Platform.Renderers {

    public interface IVisualElementRenderer<TElement, out TControl, out TController> :
        IElementRenderer<TElement, TControl, TController>
        where TElement : VisualElement
        where TController : IVisualElementController { }
}