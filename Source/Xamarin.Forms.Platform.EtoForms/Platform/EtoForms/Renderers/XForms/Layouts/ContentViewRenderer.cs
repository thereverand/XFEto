using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(ContentView), typeof(ContentViewRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class ContentViewRenderer : LayoutRenderer<ContentView> {

        public override void OnElementChanged() {
            base.OnElementChanged();
            if (Element.Content != null)
                Control.SetView(Element.Content);
        }
    }
}