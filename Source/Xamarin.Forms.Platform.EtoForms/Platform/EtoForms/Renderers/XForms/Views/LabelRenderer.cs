using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(Label), typeof(LabelRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class LabelRenderer : ViewRendererBase<Label, Eto.Forms.Label> {

        public LabelRenderer() {
            Control = new Eto.Forms.Label();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();

            BindColor(
                Control,
                Element,
                c => c.TextColor,
                Label.TextColorProperty
            );

            Bind(
                Control,
                Element,
                c => c.Text,
                Label.TextProperty
            );

            Bind(
                Control,
                Element,
                c => c.HorizontalAlign,
                Xamarin.Forms.View.HorizontalOptionsProperty,
                l => {
                    switch (l.Alignment) {
                        case LayoutAlignment.Center:
                            return Eto.Forms.HorizontalAlign.Center;

                        case LayoutAlignment.End:
                            return Eto.Forms.HorizontalAlign.Right;

                        default:
                            return Eto.Forms.HorizontalAlign.Left;
                    }
                },
                h => {
                    switch (h) {
                        case Eto.Forms.HorizontalAlign.Center:
                            return LayoutOptions.Center;

                        case Eto.Forms.HorizontalAlign.Right:
                            return LayoutOptions.End;

                        default:
                            return LayoutOptions.Start;
                    }
                });

            Bind(
                Control,
                Element,
                c => c.VerticalAlign,
                Xamarin.Forms.View.VerticalOptionsProperty,
                l => {
                    switch (l.Alignment) {
                        case LayoutAlignment.Center:
                            return Eto.Forms.VerticalAlign.Middle;

                        case LayoutAlignment.Start:
                            return Eto.Forms.VerticalAlign.Top;

                        default:
                            return Eto.Forms.VerticalAlign.Bottom;
                    }
                },
                h => {
                    switch (h) {
                        case Eto.Forms.VerticalAlign.Middle:
                            return LayoutOptions.Center;

                        case Eto.Forms.VerticalAlign.Bottom:
                            return LayoutOptions.End;

                        default:
                            return LayoutOptions.Start;
                    }
                });
        }
    }
}