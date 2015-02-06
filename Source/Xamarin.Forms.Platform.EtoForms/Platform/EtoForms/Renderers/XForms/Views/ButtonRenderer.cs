using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Controllers;
using Xamarin.Forms.Platform.EtoForms.Renderers;
using Xamarin.Forms.Platform.Renderers;
using Xamarin.Forms.Support;

[assembly: ExportRenderer(typeof(Button), typeof(ButtonRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class ButtonRenderer : ViewRendererBase<Button, Eto.Forms.Button>, IButtonRenderer<Button, Eto.Forms.Button> {

        protected void SendClick(object sender, EventArgs e) {
            Controller.SendClicked();
        }

        public ButtonRenderer() {
            Control = new Eto.Forms.Button();
        }

        public override void OnElementChanged() {
            Controller = new ButtonController(Element);
            base.OnElementChanged();

            BindColor(Control, Element, c => c.TextColor, Button.TextColorProperty);

            Bind(
               Control,
               Element,
               c => c.Text,
               Button.TextProperty
            );

            if (Element.Command != null) {
                Control.Enabled = CanExecute();
                EnabledBinding.SetControlWhen(
                   Element.Command,
                   EventNameFrom.Command.CanExecuteChanged,
                   CanExecute);
            }

            Control.Click += SendClick;
        }

        protected bool CanExecute() {
            return Element.Command.CanExecute(Element.CommandParameter);
        }

        public new ButtonController Controller { get; private set; }
    }
}