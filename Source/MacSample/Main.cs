using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
using Xamarin.Forms;
using Eto.Forms;
using SampleApp;
using Eto.Mac.Forms;

namespace MacSample
{
	class MainClass
	{
		static void Main (string[] args)
		{
			var mac = new Eto.Mac.Platform ();
			var forms = new EtoFormsPlatform (mac);

			Forms.Init (forms, TargetIdiom.Desktop);
			var window = new Form { Size = new Eto.Drawing.Size (800, 600) };
			window.Menu = new MenuBar ();
			forms.Run (
				window,
				new App ()
			);
		
		}
	}
}

