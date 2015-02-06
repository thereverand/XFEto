using System;
using Eto;
using Xamarin.Forms.Support;

namespace Xamarin.Forms.Platform.EtoForms {

    /// <summary>
    /// Represents a binding between an Element (Xamarin Forms) and a Control (Eto)
    /// </summary>
    /// <typeparam name="T">The type of the bindings value</typeparam>
    ///
    public class EtoBinding<T> : IEtoBinding<T> {

        public void ApplyBinding(IBindingContainer container = null) {
            IsValid(false);

            if (container != null && !container.Bindings.Contains(this))
                container.Bindings.Add(this);

            Control.DataContext = Element;

            Control.BindDataContext(
                (IndirectBinding<T>)ControlBinding,
                (IndirectBinding<T>)ElementBinding,
                DualBindingMode.TwoWay
            );
        }

        public bool IsValid(bool isApplied = false, bool hasControl = true, bool hasElement = true, bool throwInvalid = true) {
            if (hasControl && Control == null)
                if (throwInvalid) throw new InvalidException("IEtoBinding", ErrorMessages.NullOrDefault("Control"));
                else return false;
            if (hasElement && Element == null)
                if (throwInvalid) throw new InvalidException("IEtoBinding", ErrorMessages.NullOrDefault("Element"));
                else return false;
            if (isApplied && Binding == null)
                if (throwInvalid) throw new InvalidException("IEtoBinding", ErrorMessages.NullOrDefault("Binding"));
                else return false;

            return true;
        }

        public IEtoBinding<T> SetElementWhen(object target, string eventName, Func<T> value) {
            IsValid();
            target.When(eventName, (o, a) => {
                var bind = (IndirectBinding<T>)ElementBinding;
                bind.SetValue(Element, value());
            });

            return this;
        }

        public IEtoBinding<T> SetControlWhen(object target, string eventName, Func<T> value) {
            IsValid();
            target.When(eventName, (o, a) => {
                var bind = (IndirectBinding<T>)ControlBinding;
                bind.SetValue(Control, value());
            });
            return this;
        }

        public Eto.DualBinding<T> Binding { get; set; }

        public Eto.Forms.Control Control { get; set; }

        public Element Element { get; set; }

        public Eto.Binding ControlBinding { get; set; }

        public Eto.Binding ElementBinding { get; set; }
    }
}