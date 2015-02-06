using System.Linq;
using Eto.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(StackLayout), typeof(StackLayoutRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class StackLayoutRenderer : LayoutRenderer<StackLayout> {

        public StackLayoutRenderer() {
            Control.Content = Table = new TableLayout();
        }

        public override void Clear() {
            base.Clear();
            Table.Rows.Clear();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();
            CreateStack();
        }

        private TableLayout Table;

        protected void CreateStack() {
            Table.Rows.Clear();
            if (Element.Orientation == StackOrientation.Vertical)
                CreateVerticalStack();
            else
                CreateHorizonalStack();
        }

        protected void CreateHorizonalStack() {
            var controls = Element.Children.Select(e => new TableCell(Renderer.Render(e).Result, e.HorizontalOptions.Expands)).ToArray();
            var table = new TableLayout();
            Table.Rows.Add(new TableRow(table) { ScaleHeight = Element.VerticalOptions.Expands });
            table.Rows.Add(new TableRow(controls) { ScaleHeight = Element.VerticalOptions.Expands });

            //Table.Rows [0].Cells.Add (null);
        }

        protected void CreateVerticalStack() {
            foreach (var m in Element.Children) {
                var table = new TableLayout();

                Table.Rows.Add(new TableRow(table) { ScaleHeight = m.VerticalOptions.Expands });

                var cntrl = Renderer.Render(m).Result;
                var first = new TableCell(null, !m.HorizontalOptions.Expands);
                var center = new TableCell(null, !m.HorizontalOptions.Expands);
                var last = new TableCell(null, !m.HorizontalOptions.Expands);
                switch (m.HorizontalOptions.Alignment) {
                    case LayoutAlignment.Start:
                        first = new TableCell(cntrl, m.HorizontalOptions.Expands);
                        break;

                    case LayoutAlignment.Center:
                        center = new TableCell(cntrl, m.HorizontalOptions.Expands);
                        break;

                    case LayoutAlignment.End:
                        last = new TableCell(cntrl, m.HorizontalOptions.Expands);
                        break;

                    default:
                        var cell = new TableCell(cntrl, true);
                        table.Rows.Add(new TableRow(cell) { ScaleHeight = m.VerticalOptions.Expands });
                        continue;
                }

                table.Rows.Add(new TableRow(first, center, last) { ScaleHeight = m.VerticalOptions.Expands });
            }
            //Table.Rows.Add(null);
        }
    }
}