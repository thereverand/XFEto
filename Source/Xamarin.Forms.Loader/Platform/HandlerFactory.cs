using System;
using System.Collections.Generic;

namespace Xamarin.Forms.Platform {
    /// <summary>
    /// A factory for creating handler types.
    /// </summary>

    /// <typeparam name="TResult"></typeparam>

    public abstract class HandlerFactory<TResult> {

        protected static IHandler<TResult> Create<TSource>(TSource source) where TSource : Element {
            if (!Forms.IsInitialized)
                throw new InvalidOperationException("Xamarin Forms is not initialized");

            if (source == null)
                throw new ArgumentNullException("source");

            var handler = Registrar.Registered.GetHandler<IHandler<TResult>>(source.GetType());
            handler.Source = source;
            return handler;
        }
    }
}