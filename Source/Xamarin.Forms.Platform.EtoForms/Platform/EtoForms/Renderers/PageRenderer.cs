using Eto.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;
using Xamarin.Forms.Platform.Renderers;

[assembly: ExportRenderer(typeof(ContentPage), typeof(ContentPageRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public abstract class PageRenderer<TPage, TControl> : VisualElementRendererBase<TPage, TControl>, IPageRenderer<TPage, TControl>
        where TPage : Page
        where TControl : Control {

        protected PageRenderer() {
        }

        public override void OnElementChanged() {
            base.OnElementChanged();
            Control.LoadComplete += (s, e) => {
                Bind(Control.ParentWindow, Element, w => w.Title, Page.TitleProperty);
                BindThickness(Control.ParentWindow, Element, w => w.Padding, Page.PaddingProperty);
            };
        }
    }
}