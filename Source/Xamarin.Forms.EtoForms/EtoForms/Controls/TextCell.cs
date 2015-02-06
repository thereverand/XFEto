using System;

namespace Xamarin.Forms.EtoForms.Controls {

    [ContentProperty("Text")]
    public class LabelCell : Cell {

        public static readonly BindableProperty TextProperty = BindableProperty.Create<TextCell, string>(
            c => c.Text,
            String.Empty);

        public string Text {
            get { return (string)GetValue(TextProperty); }
            set {
                SetValue(TextProperty, value);
            }
        }
    }
}