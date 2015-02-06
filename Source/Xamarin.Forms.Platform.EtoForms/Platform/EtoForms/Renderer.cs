using System.Web.Configuration;
using Eto.Forms;
using Xamarin.Forms.Platform.Controllers;
using Xamarin.Forms.Platform.Renderers;

namespace Xamarin.Forms.Platform.EtoForms {

    public class Renderer : HandlerFactory<Control> {

        public static readonly BindableProperty ControlProperty =
            BindableProperty.CreateAttached<Renderer, Control>(b => GetControl(b), null);

        public static Control GetControl(BindableObject bindable) {
            return (Control)bindable.GetValue(ControlProperty);
        }

        public static void SetControl(BindableObject bindable, Control value) {
            bindable.SetValue(ControlProperty, value);
        }

        public static IHandler<Control> Render<TElement>(TElement elem)
            where TElement : Element {
            return Create(elem);
        }
    }
}