using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Xamarin.Forms.Platform {

    public abstract class PlatformServicesBase : IPlatformServices {

        public abstract double GetNamedSize(NamedSize size, Type targetElementType, bool useOldSizes);

        public abstract void OpenUriAction(Uri uri);

        public abstract void BeginInvokeOnMainThread(Action action);

        public abstract void StartTimer(TimeSpan interval, Func<bool> callback);

        public abstract Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken);

        public abstract Assembly[] GetAssemblies();

        public abstract TimerBase CreateTimer(Action<object> callback);

        Xamarin.Forms.ITimer IPlatformServices.CreateTimer(Action<object> callback) {
            return CreateTimer(callback);
        }

        public abstract TimerBase CreateTimer(Action<object> callback, object state, int dueTime, int period);

        Xamarin.Forms.ITimer IPlatformServices.CreateTimer(Action<object> callback, object state,
            int dueTime, int period) {
            return CreateTimer(callback, state, dueTime, period);
        }

        public abstract TimerBase CreateTimer(Action<object> callback, object state, long dueTime, long period);

        Xamarin.Forms.ITimer IPlatformServices.CreateTimer(Action<object> callback, object state, long dueTime,
            long period) {
            return CreateTimer(callback, state, dueTime, period);
        }

        public abstract TimerBase CreateTimer(Action<object> callback, object state, TimeSpan dueTime, TimeSpan period);

        Xamarin.Forms.ITimer IPlatformServices.CreateTimer(Action<object> callback, object state, TimeSpan dueTime,
            TimeSpan period) {
            return CreateTimer(callback, state, dueTime, period);
        }

        public abstract TimerBase CreateTimer(Action<object> callback, object state, uint dueTime, uint period);

        Xamarin.Forms.ITimer IPlatformServices.CreateTimer(Action<object> callback, object state, uint dueTime,
            uint period) {
            return CreateTimer(callback, state, dueTime, period);
        }

        public abstract IsolatedStorageFileBase GetUserStoreForApplication();

        Xamarin.Forms.IIsolatedStorageFile IPlatformServices.GetUserStoreForApplication() {
            return GetUserStoreForApplication();
        }

        public abstract string GetMD5Hash(string input);

        public abstract bool IsInvokeRequired { get; }
    }
}