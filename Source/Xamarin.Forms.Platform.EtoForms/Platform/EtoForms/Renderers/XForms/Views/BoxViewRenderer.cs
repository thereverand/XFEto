using Eto.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(BoxView), typeof(BoxViewRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class BoxViewRenderer : ViewRendererBase<BoxView, Panel> {

        public BoxViewRenderer() {
            Control = new Eto.Forms.Panel();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();

            BindColor(
                Control,
                Element,
                c => c.BackgroundColor,
                BoxView.ColorProperty
            );
        }
    }
}