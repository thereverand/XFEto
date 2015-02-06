using Eto.Forms;

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class ContentPageRenderer : PageRenderer<ContentPage, Panel> {

        public ContentPageRenderer() {
            Control = new Panel();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();
            Control.SetView(Element.Content);
        }
    }
}