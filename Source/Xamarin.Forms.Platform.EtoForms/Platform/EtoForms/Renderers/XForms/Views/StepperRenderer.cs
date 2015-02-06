using System;
using Eto.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(Stepper), typeof(StepperRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class StepperRenderer : ViewRendererBase<Stepper, Panel> {

        public StepperRenderer() {
            Control = new Panel();
            var table = new TableLayout();
            var plusButton = new Eto.Forms.Button() { Text = "+" };
            var minusButton = new Eto.Forms.Button() { Text = "-" };
            table.Rows.Add(new TableRow(
                new TableCell(plusButton, true),
                new TableCell(minusButton, true)
            ));
            plusButton.Click += PlusButtonClick;
            minusButton.Click += MinusButtonClick;
        }

        private void MinusButtonClick(object sender, EventArgs eventArgs) {
            var nextValue = Element.Value - Element.Increment;
            Element.Value = nextValue < Element.Minimum ? Element.Minimum : nextValue;
        }

        private void PlusButtonClick(object sender, EventArgs eventArgs) {
            var nextValue = Element.Value + Element.Increment;
            Element.Value = nextValue > Element.Maximum ? Element.Maximum : nextValue;
        }
    }
}