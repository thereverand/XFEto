using System;
using System.Reflection;

namespace Xamarin.Forms {

    internal class NamedSizeDictionary : ConcurrentDictionary<TargetIdiom, ConcurrentDictionary<Type, ConcurrentDictionary<NamedSize, double>>> { }

    public static class NamedSizes {

        private static NamedSizeDictionary Sizes { get; set; }

        public static void Register() {
            Sizes = new NamedSizeDictionary();
            RegisterSizes();
        }

        private const double DefaultSize = 12.0;

        public static double SizeOf(NamedSize size, Type control) {
            if (!Sizes.ContainsKey(Device.Idiom))
                return DefaultSize;
            if (!Sizes[Device.Idiom].ContainsKey(control))
                return DefaultSize;
            if (!Sizes[Device.Idiom][control].ContainsKey(size))
                return DefaultSize;
            return Sizes[Device.Idiom][control][size];
        }

        private static void RegisterSizes() {
            foreach (var a in Device.GetAssemblies()) {
                var namedSizes = a.GetCustomAttributes<NamedSizeAttribute>();
                foreach (var size in namedSizes) {
                    if (!Sizes.ContainsKey(size.Idiom))
                        Sizes[size.Idiom] = new ConcurrentDictionary<Type, ConcurrentDictionary<NamedSize, double>>();
                    if (!Sizes[size.Idiom].ContainsKey(size.Target))
                        Sizes[size.Idiom][size.Target] = new ConcurrentDictionary<NamedSize, double>();
                    Sizes[size.Idiom][size.Target][size.WhenSize] = size.IsSize;
                }
            }
        }
    }
}