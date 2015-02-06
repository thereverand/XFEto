using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

// ReSharper disable CheckNamespace
// @thereverand: It belongs in the Support folder, but not in the UI namespace.

namespace Xamarin.Forms {

    public static class Extensions {

        #region Property Changes

        /// <summary>
        /// Defines an <see cref="Action"/> which will be invoked when the specified <see cref="BindableProperty"/> changes.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <param name="action"></param>
        public static void OnPropertyChange(this BindableObject obj, BindableProperty property, Action action) {
            OnPropertyChange(obj, property.PropertyName, action);
        }

        /// <summary>
        /// Defines an <see cref="Action"/> which will be invoked when the specified property changes.
        /// </summary>
        /// <param name="obj">The Target <see cref="System.Object"/>.</param>
        /// <param name="propertyName">The Name of the Property.</param>
        /// <param name="action">The <see cref="System.Action"/> to invoke.</param>
        public static void OnPropertyChange(this INotifyPropertyChanged obj, string propertyName, Action action) {
            obj.PropertyChanged += (sender, args) => {
                if (args.PropertyName == propertyName)
                    action();
            };
        }

        #endregion Property Changes

        #region The "Why is it not" or "Why does it not" methods...

        /// <summary>
        /// Determines if the questionable type is compatible with this Type, because this method is missing in .Net Portable
        /// </summary>
        /// <param name="type"></param>
        /// <param name="questionableType"></param>
        /// <returns></returns>
        public static bool IsAssignableFrom(this Type type, Type questionableType) {
            return type.GetTypeInfo().IsAssignableFrom(questionableType.GetTypeInfo());
        }

        #endregion The "Why is it not" or "Why does it not" methods...
    }
}