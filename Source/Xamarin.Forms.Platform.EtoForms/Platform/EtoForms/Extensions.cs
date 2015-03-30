using System;
using System.Reflection;
using Eto;
using Eto.Forms;
using Panel = Eto.Forms.Panel;

namespace Xamarin.Forms.Platform.EtoForms
{

	public static class Extensions
	{

		/// <summary>
		/// Performs the action on the named Event of the given target. If this object is an <see cref="Widget"/> it adds the handler
		/// to the PropertyStore for that Widget, which is consistent with Eto behavior.
		/// Otherwise an attempt is made to add the handler to the appropriate event.
		/// Should an exception occur, nothing happens.
		/// </summary>
		/// <param name="target">The Object sourcing the Event</param>
		/// <param name="eventName">The name of the Event</param>
		/// <param name="action">A handler for the target event</param>
		public static void When (this object target, string eventName, Action<object, EventArgs> action)
		{
			if (target == null)
				return;

			if (target is Widget) {
				var widget = target as Widget;
				widget.Properties.AddHandlerEvent (eventName, action);
				return;
			}

			var tType = target.GetType ();
			try {
				var rEvent = tType.GetRuntimeEvent (eventName);
				if (rEvent != null)
					rEvent.AddEventHandler (target, action);
			} catch {
				// ignored
			}
		}

		public static void SetPage (this Form panel, Page page)
		{
			
			var handler = Renderer.Render (page);
			panel.Content = handler.Result;
			panel.Bind<String> ("Title", page, "Title");

		}

		public static void SetView (this Panel panel, View view)
		{
			
			var handler = Renderer.Render (view);
			panel.Content = handler.Result;
		}
	}
}