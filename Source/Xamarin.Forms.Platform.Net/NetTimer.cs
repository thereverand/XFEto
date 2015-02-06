using System;
using System.Threading;

namespace Xamarin.Forms.Platform.Net {

    public class NetTimer : TimerBase {
        private readonly Timer Timer;

        public NetTimer(Timer timer) {
            Timer = timer;
        }

        public override void Change(int dueTime, int period) {
            Timer.Change(dueTime, period);
        }

        public override void Change(long dueTime, long period) {
            Timer.Change(dueTime, period);
        }

        public override void Change(TimeSpan dueTime, TimeSpan period) {
            Timer.Change(dueTime, period);
        }

        public override void Change(uint dueTime, uint period) {
            Timer.Change(dueTime, period);
        }
    }
}