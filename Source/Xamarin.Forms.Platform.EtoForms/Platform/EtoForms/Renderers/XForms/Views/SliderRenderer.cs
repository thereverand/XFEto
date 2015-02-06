using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(Slider), typeof(SliderRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class SliderRenderer : ViewRendererBase<Slider, Eto.Forms.Slider> {

        public SliderRenderer() {
            Control = new Eto.Forms.Slider();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();
            Bind(Control, Element, c => c.MinValue, Slider.MinimumProperty);
            Bind(Control, Element, c => c.MaxValue, Slider.MaximumProperty);
            Bind(Control, Element, c => c.Value, Slider.ValueProperty);
        }
    }
}