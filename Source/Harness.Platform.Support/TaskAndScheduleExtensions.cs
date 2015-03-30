using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xamarin.Forms
{

	public static class EnumerableExtensons
	{

		public static void ForEach<T> (this IEnumerable<T> enumerable, Action<T> action)
		{
			foreach (var i in enumerable) {
				action (i);
			}
		}
	}

	public static class TaskAndScheduleExtensions
	{

		#region Fun things to do with tasks and schedulers...

		/// <summary>
		/// Invokes the given action as a Task using this TaskScheduler.
		/// </summary>
		/// <param name="scheduler"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static Task ScheduleAction (this TaskScheduler scheduler, Action action)
		{
			return Task.Factory.StartNew (
				action,
				Task.Factory.CancellationToken,
				TaskCreationOptions.DenyChildAttach,
				scheduler);
		}

		#endregion Fun things to do with tasks and schedulers...
	}
}