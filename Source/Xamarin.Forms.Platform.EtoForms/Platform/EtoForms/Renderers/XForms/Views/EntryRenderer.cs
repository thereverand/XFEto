using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(Entry), typeof(EntryRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class EntryRenderer : ViewRendererBase<Entry, Eto.Forms.TextBox> {

        public EntryRenderer() {
            Control = new Eto.Forms.TextBox();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();

            Bind(
                Control,
                Element,
                c => c.PlaceholderText,
                Entry.PlaceholderProperty);
            Bind(
                Control,
                Element,
                c => c.Text,
                Entry.TextProperty);

            BindColor(
                Control,
                Element,
                c => c.TextColor,
                Entry.TextColorProperty
            );
        }
    }
}