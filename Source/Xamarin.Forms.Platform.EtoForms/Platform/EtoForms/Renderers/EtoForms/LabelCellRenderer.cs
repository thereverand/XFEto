using Xamarin.Forms.EtoForms.Controls;

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class LabelCellRenderer : CellRendererBase<LabelCell> {

        public override void OnElementChanged() {
            base.OnElementChanged();
            Control.Content = new Eto.Forms.Label();
            Bind((Eto.Forms.Label)Control.Content, Element, c => c.Text, LabelCell.TextProperty);
        }
    }
}