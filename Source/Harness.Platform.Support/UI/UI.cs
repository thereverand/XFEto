using System.Threading;
using System.Threading.Tasks;

namespace Xamarin.Forms {

    /// <summary>
    /// Providers information relevant to the current environments ability to manipulate and display a user interface.
    /// </summary>
    public static class UI {

        /// <summary>
        /// Contains the TaskScheduler for the UI Thread.
        /// </summary>
        /// <remarks>
        ///     This technique is recommended by the
        ///     <see href="http://developer.xamarin.com/guides/cross-platform/application_fundamentals/building_cross_platform_applications/part_5_-_practical_code_sharing_strategies/#Threading">
        ///     Building Cross Platform Applications
        ///     </see> guide for obtaining the TaskScheduler for the UI thread. Tasks using this Scheduler are UI thread bound and interaction safe.
        /// </remarks>
        public static readonly TaskScheduler Scheduler = TaskScheduler.FromCurrentSynchronizationContext();

        /// <summary>
        /// Contains the SynchronizationContext for the UI Thread.
        /// </summary>
        public static readonly SynchronizationContext Context = SynchronizationContext.Current;
    }
}