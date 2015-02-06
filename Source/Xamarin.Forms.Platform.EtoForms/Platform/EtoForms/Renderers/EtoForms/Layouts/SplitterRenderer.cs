using Eto.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;
using Xamarin.Forms.Support;
using Splitter = Xamarin.Forms.EtoForms.Controls.Splitter;

[assembly: ExportRenderer(typeof(Xamarin.Forms.EtoForms.Controls.Panel), typeof(PanelRenderer))]
[assembly: ExportRenderer(typeof(Splitter), typeof(SplitterRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class SplitterRenderer : ViewRendererBase<Splitter, Eto.Forms.Splitter> {

        public SplitterRenderer() {
            Control = new Eto.Forms.Splitter();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();
            if (Element.Panels.Count > 2 || Element.Panels.Count < 2)
                throw new InvalidElementException("Splitter", "Contains must have (2) Panels");

            var p1 = Element.Panels[0];
            var p2 = Element.Panels[1];
            var panel1 = Renderer.Render(p1).Result;
            var panel2 = Renderer.Render(p2).Result;

            var panel1Fixed = Splitter.GetIsFixed(p1);
            var panel2Fixed = Splitter.GetIsFixed(p2);

            if (panel1Fixed && panel2Fixed) {
                throw new InvalidElementException("Splitter", "Both Panels cannot be fixed");
            }

            Control.Panel1 = panel1;
            Control.Panel2 = panel2;

            Control.FixedPanel =
                panel1Fixed || panel2Fixed
                ? panel1Fixed ? SplitterFixedPanel.Panel1 : SplitterFixedPanel.Panel2
                : SplitterFixedPanel.None;
        }
    }
}