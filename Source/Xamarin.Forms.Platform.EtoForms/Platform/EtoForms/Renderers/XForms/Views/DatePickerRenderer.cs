using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(DatePicker), typeof(DatePickerRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class DatePickerRenderer : ViewRendererBase<DatePicker, Eto.Forms.DateTimePicker> {

        public DatePickerRenderer() {
            Control = new Eto.Forms.DateTimePicker();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();
            Bind(
                Control,
                Element,
                c => c.MaxDate,
                DatePicker.MaximumDateProperty
            );
            Bind(
                Control,
                Element,
                c => c.MinDate,
                DatePicker.MinimumDateProperty);
            Bind(
                Control,
                Element,
                c => c.Value,
                DatePicker.DateProperty);
        }
    }
}