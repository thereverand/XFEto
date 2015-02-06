using System;

namespace Xamarin.Forms.Support {

    public static class ErrorMessages {

        public static string IncompatibleTypes(Type targetType, Type sourceType) {
            return targetType.Name + "is not assignable to " + sourceType.Name;
        }

        public static string NullOrDefault(string name) {
            return name + " is null or default.";
        }
    }
}