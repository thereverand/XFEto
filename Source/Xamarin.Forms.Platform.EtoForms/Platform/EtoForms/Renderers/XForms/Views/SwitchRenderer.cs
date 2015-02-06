using Eto.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(Switch), typeof(SwitchRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class SwitchRenderer : ViewRendererBase<Switch, CheckBox> {

        public SwitchRenderer() {
            Control = new CheckBox();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();
            Bind(Control, Element, c => c.Checked, Switch.IsToggledProperty);
        }
    }
}