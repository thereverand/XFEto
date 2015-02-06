using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(SearchBar), typeof(SearchBarRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class SearchBarRenderer : ViewRendererBase<SearchBar, Eto.Forms.TableLayout> {
        private Eto.Forms.TextBox SearchText;
        private Eto.Forms.Button SearchButton;

        public SearchBarRenderer() {
            Control = new Eto.Forms.TableLayout();
            SearchText = new Eto.Forms.TextBox() { PlaceholderText = "Search..." };
            SearchButton = new Eto.Forms.Button() { Text = "Search" };
            Control.Rows.Add(
                new Eto.Forms.TableRow(
                    new Eto.Forms.TableCell(SearchText) { ScaleWidth = true },
                    new Eto.Forms.TableCell(SearchButton) { ScaleWidth = false }) {
                        ScaleHeight = true
                    });
        }

        public override void OnElementChanged() {
            base.OnElementChanged();

            Bind(SearchText, Element, c => c.Text, SearchBar.TextProperty);
            Bind(SearchText, Element, c => c.PlaceholderText, SearchBar.PlaceholderProperty);
            SearchButton.Click += (s, e) => Element.OnSearchButtonPressed();
        }
    }
}