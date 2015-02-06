using System;
using Xamarin.Forms.Platform;

namespace Xamarin.Forms {

    public static class Forms {
        internal static bool IsInitialized;

        public static Application Application { get; set; }

        public static PlatformBase Platform { get; private set; }

        public static void Init(PlatformBase platform, TargetIdiom idiom) {
            Platform = platform;
            platform.Init(idiom);
            Device.OS = TargetPlatform.Other;
            Device.Idiom = idiom;

            Registrar.RegisterAll(new[]{
				typeof(ExportRendererAttribute)
			});
            NamedSizes.Register();

            Forms.IsInitialized = true;
        }

        private static event Action<VisualElement, object> ViewActivated;

        public static void Activated<T>(Action<VisualElement, T> handler) {
            if (handler != null) ViewActivated += (v, t) => { if (t.GetType() is T) handler(v, (T)t); };
        }

        internal static void OnViewActivated(VisualElement element, Object control) {
            if (Forms.ViewActivated != null)
                Forms.ViewActivated(element, control);
        }
    }
}