using System;

namespace Xamarin.Forms.Platform.EtoForms {

    public interface IEtoBinding<in T> : IEtoBinding {

        /// <summary>
        /// Sets the value of the bound Element Property to the result of the provided Func
        /// </summary>
        /// <param name="target"></param>
        /// <param name="eventName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IEtoBinding<T> SetElementWhen(object target, string eventName, Func<T> value);

        /// <summary>
        /// Sets the value of the bound Control Property to the result of the provided Func
        /// </summary>
        /// <param name="target"></param>
        /// <param name="eventName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IEtoBinding<T> SetControlWhen(object target, string eventName, Func<T> value);
    }

    public interface IEtoBinding {

        /// <summary>
        /// Finishes binding the Control to the Element and optionally adds it to the given container.
        /// </summary>
        /// <param name="container">The binding container to add the finished binding to.</param>
        void ApplyBinding(IBindingContainer container = null);

        /// <summary>
        /// The bound Control
        /// </summary>
        Eto.Forms.Control Control { get; set; }

        /// <summary>
        /// The bound Element
        /// </summary>
        Element Element { get; set; }

        /// <summary>
        /// The Controls Binding
        /// </summary>
        Eto.Binding ControlBinding { get; set; }

        /// <summary>
        /// The Element Binding
        /// </summary>
        Eto.Binding ElementBinding { get; set; }
    }
}