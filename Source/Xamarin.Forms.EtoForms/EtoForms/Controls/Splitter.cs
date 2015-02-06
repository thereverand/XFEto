using System.Collections.Generic;
using Eto;
using Eto.Forms;

namespace Xamarin.Forms.EtoForms.Controls {

    [ContentProperty("Panels")]
    public class Splitter : View {

        public Splitter()
            : base() {
        }

        protected override void OnBindingContextChanged() {
            SetInheritedBindingContext(Panels[0], BindingContext);
            SetInheritedBindingContext(Panels[1], BindingContext);
            base.OnBindingContextChanged();
        }

        public static readonly BindableProperty IsFixedProperty =
            BindableProperty.CreateAttached<Splitter, bool>(b => GetIsFixed(b), false);

        public static bool GetIsFixed(BindableObject bindable) {
            return (bool)bindable.GetValue(IsFixedProperty);
        }

        public static void SetIsFixed(BindableObject bindable, bool value) {
            bindable.SetValue(IsFixedProperty, value);
        }

        public static readonly BindableProperty OrientationProperty =
            BindableProperty.Create<Splitter, Eto.Forms.SplitterOrientation>(s => s.Orientation,
                Eto.Forms.SplitterOrientation.Horizontal);

        public SplitterOrientation Orientation {
            get { return (SplitterOrientation)GetValue(OrientationProperty); }
            set {
                SetValue(OrientationProperty, value);
            }
        }

        public static readonly BindableProperty PanelsProperty =
            BindableProperty.Create<Splitter, IList<Panel>>(p => p.Panels, new ExtendedObservableCollection<Panel>());

        public IList<Panel> Panels {
            get { return (IList<Panel>)GetValue(PanelsProperty); }
            set { SetValue(PanelsProperty, value); }
        }
    }
}