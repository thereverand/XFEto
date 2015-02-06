using System;
using System.Threading;
using Eto.Forms;

namespace Xamarin.Forms.Platform.EtoForms {

    internal class EtoTimerBase : Platform.TimerBase, IDisposable {
        private readonly UITimer _timer;

        public EtoTimerBase(UITimer timer) {
            _timer = timer;
            _timer.Start();
        }

        public EtoTimerBase(Action<object> callback) {
            _timer = new UITimer();
            Change(0, Timeout.Infinite);
            _timer.Elapsed += Elapsed(null, callback);
            _timer.Start();
        }

        public EtoTimerBase(Action<object> callback, object state, int dueTime, int period) {
            _timer = new UITimer();
            ChangeDue(dueTime / 1000);
            ChangeInterval(period / 1000);
            _timer.Elapsed += Elapsed(state, callback);
            _timer.Start();
        }

        public EtoTimerBase(Action<object> callback, object state, long dueTime, long period) {
            _timer = new UITimer();
            ChangeDue(dueTime / 1000);
            ChangeInterval(period / 1000);
            _timer.Elapsed += Elapsed(state, callback);
            _timer.Start();
        }

        public EtoTimerBase(Action<object> callback, object state, TimeSpan dueTime, TimeSpan period) {
            _timer = new UITimer();
            ChangeDue(dueTime.TotalSeconds);
            ChangeInterval(dueTime.TotalSeconds);
            _timer.Elapsed += Elapsed(state, callback);
            _timer.Start();
        }

        private EventHandler<EventArgs> Elapsed(object state, Action<object> callback) {
            return (s, e) => {
                callback(state);
            };
        }

        private void ChangeDue(double newDue) {
            _timer.Stop();
            _timer.Interval = newDue;
            _timer.Start();
        }

        private void ChangeInterval(double newPeriod) {
            EventHandler<EventArgs> handler = null;
            handler = (s, e) => {
                ChangeDue(newPeriod);
                _timer.Elapsed -= handler;
            };
            _timer.Elapsed += handler;
        }

        public override void Change(uint dueTime, uint period) {
            ChangeDue(dueTime / 1000);
            ChangeInterval(period / 1000);
        }

        public override void Change(TimeSpan dueTime, TimeSpan period) {
            ChangeDue(dueTime.TotalSeconds);
            ChangeInterval(period.TotalSeconds);
        }

        public override void Change(long dueTime, long period) {
            ChangeDue(dueTime / 1000);
            ChangeInterval(period / 1000);
        }

        public override void Change(int dueTime, int period) {
            ChangeDue(dueTime / 1000);
            ChangeInterval(period / 1000);
        }

        ~EtoTimerBase() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing) {
            if (_disposed)
                return;
            _disposed = true;

            if (disposing) {
                _timer.Dispose();
            }
        }
    }
}