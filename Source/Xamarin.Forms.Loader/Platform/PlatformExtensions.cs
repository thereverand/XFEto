using System;
using System.Collections.Generic;

namespace Xamarin.Forms.Platform
{

	public static class PlatformExtensions
	{

		#region Exposing Hidden Methods and Properties

		public static IReadOnlyList<T> TemplatedItems<T> (this ItemsView<T> itemsView)
            where T : BindableObject
		{
			if (itemsView == null)
				throw new ArgumentNullException ("itemsView");
			return itemsView.TemplatedItems;
		}

		public static void HandleEval (this WebView webView, Action<string> OnEval)
		{
			webView.EvalRequested += (sender, e) => OnEval (e.Data);
		}

		public static void NotifyRowTapped (this ListView view, int index)
		{
			if (view == null)
				throw new ArgumentNullException ("view");
			view.NotifyRowTapped (index);
		}

		public static void Apply (this Style style, BindableObject bindable)
		{
			if (style == null)
				throw new ArgumentNullException ("style");
			style.Apply (bindable);
		}

		public static void OnSearchButtonPressed (this SearchBar searchBar)
		{
			if (searchBar == null)
				throw new ArgumentNullException ("searchBar");
			searchBar.OnSearchButtonPressed ();
		}

		//public static void Load(this WebViewSource source, WebViewSourceLoadHandler loadHandler) {
		//    source.Load(loadHandler);
		//}

		#endregion Exposing Hidden Methods and Properties
	}
}