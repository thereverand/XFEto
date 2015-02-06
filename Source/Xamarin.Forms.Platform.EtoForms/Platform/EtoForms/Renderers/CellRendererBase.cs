using Xamarin.Forms;
using Xamarin.Forms.EtoForms.Controls;
using Xamarin.Forms.Platform.EtoForms.Renderers;
using Xamarin.Forms.Platform.Renderers;
using Panel = Eto.Forms.Panel;

[assembly: ExportRenderer(typeof(ViewCell), typeof(ViewCellRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public abstract class CellRendererBase<TCell> : ElementRendererBase<TCell, Panel>, ICellRenderer<TCell, Panel>
        where TCell : Cell {

        protected CellRendererBase() {
            Control = new Panel();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();
            Bind(Control, Element, c => c.Enabled, Cell.IsEnabledProperty);
            BindColor(Control, Element, c => c.BackgroundColor, CellStyle.BackgroundColorProperty);
        }
    }
}