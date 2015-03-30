using System;
using Xamarin.Forms.Platform.Handlers;

namespace Xamarin.Forms.EtoForms.Handlers
{

	internal class SourceLoadHandler : WebViewSourceLoadHandler
	{

		public Eto.Forms.WebView WebView { get; set; }

		public SourceLoadHandler (Eto.Forms.WebView webView)
		{
			WebView = webView;

		}



		public override void LoadUrl (string url)
		{
			WebView.Url = new Uri (url);
		}

		public override void LoadHtml (string html, string baseUrl)
		{
			WebView.LoadHtml (html, new Uri (baseUrl));
		}
	}
}