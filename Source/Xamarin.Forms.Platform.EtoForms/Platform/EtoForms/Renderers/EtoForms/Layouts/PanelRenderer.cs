using Eto.Forms;

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class PanelRenderer : LayoutRenderer<Xamarin.Forms.EtoForms.Controls.Panel> {

        public PanelRenderer() {
        }

        public override void Clear() {
            base.Clear();
            Control.Content = null;
        }

        public override void OnElementChanged() {
            base.OnElementChanged();
            if (Element.Content != null)
                Control.Content = Renderer.Render(Element.Content).Result;
        }
    }
}