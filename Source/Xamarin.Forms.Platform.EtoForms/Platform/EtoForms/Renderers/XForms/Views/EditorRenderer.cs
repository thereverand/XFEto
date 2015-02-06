using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(Editor), typeof(EditorRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class EditorRenderer : ViewRendererBase<Editor, Eto.Forms.TextArea> {

        public EditorRenderer() {
            Control = new Eto.Forms.TextArea();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();

            Bind(
                Control,
                Element,
                c => c.Text,
                Editor.TextProperty
            );
        }
    }
}