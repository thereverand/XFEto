using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(ProgressBarRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class ProgressBarRenderer : ViewRendererBase<ProgressBar, Eto.Forms.ProgressBar> {

        public ProgressBarRenderer() {
            Control = new Eto.Forms.ProgressBar();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();

            Bind<Eto.Forms.ProgressBar, ProgressBar, int, double>(
                Control,
                Element,
                c => c.Value,
                ProgressBar.ProgressProperty,
                p => (int)(p * 100),
                p => p / 100
            );
        }
    }
}