using System;

namespace Xamarin.Forms.Platform {

    public abstract class TimerBase : Xamarin.Forms.ITimer {

        public abstract void Change(int dueTime, int period);

        public abstract void Change(long dueTime, long period);

        public abstract void Change(TimeSpan dueTime, TimeSpan period);

        public abstract void Change(uint dueTime, uint period);
    }
}