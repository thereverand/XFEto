using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(Picker), typeof(PickerRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class PickerRenderer : ViewRendererBase<Picker, Eto.Forms.DropDown> {

        public PickerRenderer() {
            Control = new Eto.Forms.DropDown();
        }

        public override void Clear() {
            Control.Items.Clear();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();

            foreach (var i in Element.Items) {
                Control.Items.Add(i);
            }
        }
    }
}