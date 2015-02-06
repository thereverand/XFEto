using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Eto.Forms;
using Xamarin.Forms.Platform.Net;

namespace Xamarin.Forms.Platform.EtoForms {

    internal class EtoServices : PlatformServicesBase {
        private readonly HttpClient httpClient = new HttpClient();

        #region IPlatformServices Members

        public override void BeginInvokeOnMainThread(Action action) {
            Eto.Forms.Application.Instance.AsyncInvoke(action);
        }

        public override TimerBase CreateTimer(Action<object> callback, object state, uint dueTime, uint period) {
            return new EtoTimerBase(callback, state, dueTime, period);
        }

        public override TimerBase CreateTimer(Action<object> callback, object state, TimeSpan dueTime, TimeSpan period) {
            return new EtoTimerBase(callback, state, dueTime, period);
        }

        public override TimerBase CreateTimer(Action<object> callback, object state, long dueTime, long period) {
            return new EtoTimerBase(callback, state, dueTime, period);
        }

        public override TimerBase CreateTimer(Action<object> callback, object state, int dueTime, int period) {
            return new EtoTimerBase(callback, state, dueTime, period);
        }

        public override TimerBase CreateTimer(Action<object> callback) {
            return new EtoTimerBase(callback);
        }

        public override Assembly[] GetAssemblies() {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        public override Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken) {
            if (uri.IsAbsoluteUri && uri.Scheme == "http")
                return httpClient.GetStreamAsync(uri);

            if (uri.IsAbsoluteUri && uri.Scheme == "file")
                return Task.FromResult((Stream)File.OpenRead(
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        uri.LocalPath
                    )
                ));

            return Task.FromResult((Stream)new MemoryStream());
        }

        public override IsolatedStorageFileBase GetUserStoreForApplication() {
            return LocalIsolatedStorage.Create();
        }

        public override string GetMD5Hash(string input) {
            var hasher = MD5.Create();
            var data = Encoding.Unicode.GetBytes(input);
            var result = hasher.ComputeHash(data, 0, data.Length);
            return Encoding.Unicode.GetString(result);
        }

        public override bool IsInvokeRequired {
            get { return true; }
        }

        public override void OpenUriAction(Uri uri) {
            Eto.Forms.Application.Instance.Open(uri.ToString());
        }

        public override void StartTimer(TimeSpan interval, Func<bool> callback) {
            var timer = new UITimer { Interval = interval.TotalSeconds };
            timer.Elapsed += (s, e) => {
                if (!callback()) {
                    timer.Stop();
                }
            };
            timer.Start();
        }

        public override double GetNamedSize(NamedSize size, Type targetElementType, bool useOldSizes) {
            return NamedSizes.SizeOf(size, targetElementType);
        }

        #endregion IPlatformServices Members
    }
}