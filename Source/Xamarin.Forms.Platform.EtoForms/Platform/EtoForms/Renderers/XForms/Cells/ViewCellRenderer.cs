using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(ViewCell), typeof(ViewCellRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class ViewCellRenderer : CellRendererBase<ViewCell> {

        public override void OnElementChanged() {
            base.OnElementChanged();
            if (Element.View != null)
                Control.SetView(Element.View);
        }
    }
}