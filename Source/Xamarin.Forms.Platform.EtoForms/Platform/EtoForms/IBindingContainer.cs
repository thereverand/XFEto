using System.Collections.Generic;

namespace Xamarin.Forms.Platform.EtoForms {

    /// <summary>
    /// Defines a container containing renderer bindings.
    /// </summary>
    public interface IBindingContainer {

        IList<IEtoBinding> Bindings { get; }
    }
}