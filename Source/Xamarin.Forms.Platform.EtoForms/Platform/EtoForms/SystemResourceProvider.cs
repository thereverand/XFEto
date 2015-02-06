using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms;

[assembly: Dependency(typeof(SystemResourceProvider))]

namespace Xamarin.Forms.Platform.EtoForms {

    internal class SystemResourceProvider : SystemResourceProviderBase {

        public override ResourceDictionary GetSystemResources() {
            return new ResourceDictionary();
        }
    }
}