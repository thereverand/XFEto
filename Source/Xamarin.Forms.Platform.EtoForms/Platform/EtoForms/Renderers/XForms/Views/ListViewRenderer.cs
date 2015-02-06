using System.Collections;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.EtoForms.Controls;
using Xamarin.Forms.Platform.EtoForms.Renderers;
using Panel = Eto.Forms.Panel;
using TableCell = Eto.Forms.TableCell;
using TableLayout = Eto.Forms.TableLayout;
using TableRow = Eto.Forms.TableRow;

[assembly: ExportRenderer(typeof(ListView), typeof(ListViewRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class ItemsViewRenderer<T, TControl, TElement> : ViewRendererBase<TElement, TControl>
        where TControl : Eto.Forms.Control
        where TElement : ItemsView<T>
        where T : BindableObject {
    }

    public class ListViewRenderer : ViewRendererBase<ListView, TableLayout> {
        private Cell Selected;

        public ListViewRenderer() {
            Control = new TableLayout();
        }

        public override void Clear() {
            base.Clear();
            Control.Rows.Clear();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();
            CreateList();
        }

        protected virtual void CreateList() {
            foreach (var i in Element.TemplatedItems()) {
                var c = i;
                var enabledStyle = CellStyle.GetEnabled(i);
                var disabledStyle = CellStyle.GetDisabled(i);
                var selectedStyle = CellStyle.GetSelected(i);

                ApplyEnabledOrDisabled(i, enabledStyle, disabledStyle, selectedStyle);

                var cntrl = (Panel)Renderer.Render(i).Result;

                cntrl.MouseUp += (s, e) => {
                    if (Selected != null) {
                        ApplyEnabledOrDisabled(Selected, enabledStyle, disabledStyle, selectedStyle);
                    }
                    ChangeSelected(this, Element, c);
                    ApplySelected(c, enabledStyle, disabledStyle, selectedStyle);
                };

                var cell = new TableCell(cntrl, true);
                var row = new TableRow(cell) { ScaleHeight = true };
                Control.Rows.Add(row);
            }

            Control.Rows.Add(null);
        }

        private static void ChangeSelected(ListViewRenderer r, ListView element, Cell cell) {
            var indx = ((IList)element.TemplatedItems()).IndexOf(cell);
            element.SelectedItem = element.ItemsSource.Cast<object>().ElementAt(indx);
            element.NotifyRowTapped(indx);
            r.Selected = cell;
        }

        private static void ApplySelected(Cell cell, Style enabled, Style disabled, Style selected) {
            selected.Apply(cell);
        }

        private static void ApplyEnabledOrDisabled(Cell cell, Style enabled, Style disabled, Style selected) {
            if (cell.IsEnabled) {
                enabled.Apply(cell);

                return;
            }

            disabled.Apply(cell);
        }
    }
}