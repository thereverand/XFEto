using Eto.Forms;
using Xamarin.Forms.Platform.Renderers;

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class LayoutRenderer<TLayout> : ViewRendererBase<TLayout, Panel>, ILayoutRenderer<TLayout, Panel>
        where TLayout : Layout {

        public LayoutRenderer() {
            Control = new Panel();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();
            BindThickness(Control, Element, c => c.Padding, Layout.PaddingProperty);
        }
    }
}