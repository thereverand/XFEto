using Xamarin.Forms;
using Xamarin.Forms.EtoForms.Handlers;
using Xamarin.Forms.Platform.Controllers;
using Xamarin.Forms.Platform.EtoForms.Renderers;
using Xamarin.Forms.Platform.Renderers;

[assembly: ExportRenderer (typeof(WebView), typeof(WebViewRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers
{

	public class WebViewRenderer : ViewRendererBase<WebView, Eto.Forms.WebView>, IWebViewRenderer<WebView, Eto.Forms.WebView>
	{
		private SourceLoadHandler loadHandler;

		public WebViewRenderer ()
		{
			Control = new Eto.Forms.WebView ();
			loadHandler = new SourceLoadHandler (Control);
		}

		public new WebViewController Controller { get; private set; }

		public override void OnElementChanged ()
		{
			Controller = new WebViewController (Element);
			base.OnElementChanged ();
			Element.HandleEval (script => Control.ExecuteScript (script));
			Controller.LoadSource (loadHandler);

		}
	}
}