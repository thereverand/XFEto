using Eto.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(ActivityIndicator), typeof(ActivityIndicatorRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class ActivityIndicatorRenderer : ViewRendererBase<ActivityIndicator, Spinner> {

        public ActivityIndicatorRenderer() {
            Control = new Spinner();
        }
    }
}