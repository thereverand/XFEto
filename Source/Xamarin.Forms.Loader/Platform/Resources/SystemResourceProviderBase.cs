using Xamarin.Forms;
using Xamarin.Forms.Platform;

namespace Xamarin.Forms.Platform {

    public abstract class SystemResourceProviderBase : ISystemResourcesProvider {

        public abstract ResourceDictionary GetSystemResources();

        IResourceDictionary ISystemResourcesProvider.GetSystemResources() {
            return GetSystemResources();
        }
    }
}