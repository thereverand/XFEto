using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(TextCell), typeof(TextCellRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class TextCellRenderer : CellRendererBase<TextCell> {

        public override void OnElementChanged() {
            base.OnElementChanged();

            Control.Content = new Eto.Forms.Label();

            Bind((Eto.Forms.Label)Control.Content, Element, c => c.Text, TextCell.TextProperty);
            BindColor((Eto.Forms.Label)Control.Content, Element, c => c.TextColor, TextCell.TextColorProperty);
            Bind((Eto.Forms.Label)Control.Content, Element, c => c.ToolTip, TextCell.DetailProperty);
        }
    }
}