using Xamarin.Forms;
using Xamarin.Forms.Platform.Controllers;
using Xamarin.Forms.Platform.EtoForms.Renderers;
using Xamarin.Forms.Platform.Renderers;

[assembly: ExportRenderer(typeof(VisualElement), typeof(VisualElementRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class VisualElementRendererBase<TModel, TControl> : ElementRendererBase<TModel, TControl>, IVisualElementRenderer<TModel, TControl, VisualElementController>
        where TModel : VisualElement
        where TControl : Eto.Forms.Control {
        protected IEtoBinding<bool> EnabledBinding;

        public override void Clear() {
            base.Clear();
            EnabledBinding = null;
        }

        public override void OnElementChanged() {
            Controller = new VisualElementController(Element);
            base.OnElementChanged();

            BindColor(
                Control,
                Element,
                c => c.BackgroundColor,
                VisualElement.BackgroundColorProperty);

            Control.LoadComplete += (sender, args) => {
                Bind(
                    Control,
                    Element,
                    c => c.Height,
                    VisualElement.HeightRequestProperty);

                Bind(
                    Control,
                    Element,
                    c => c.Width,
                    VisualElement.WidthRequestProperty);
            };

            Bind(
                Control,
                Element,
                c => c.Enabled,
                VisualElement.IsEnabledProperty);

            Bind(
                Control,
                Element,
                c => c.Visible,
                VisualElement.IsVisibleProperty);

            EnabledBinding =
               Bind(
                   Control,
                   Element,
                   c => c.Enabled,
                   VisualElement.IsEnabledProperty
               );
        }

        public new VisualElementController Controller { get; private set; }
    }
}