using Xamarin.Forms;
using Xamarin.Forms.Platform.Controllers;
using Xamarin.Forms.Platform.EtoForms.Renderers;
using Xamarin.Forms.Platform.Renderers;

[assembly: ExportRenderer(typeof(View), typeof(VisualElementRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class ViewRendererBase<TModel, TControl> :
        VisualElementRendererBase<TModel, TControl>,
        IViewRenderer<TModel, TControl, ViewController>
        where TModel : View
        where TControl : Eto.Forms.Control {

        public override void OnElementChanged() {
            Controller = new ViewController(Element);
            base.OnElementChanged();
        }

        public new ViewController Controller { get; private set; }
    }
}