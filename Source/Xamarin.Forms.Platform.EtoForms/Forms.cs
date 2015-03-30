using System;
using Eto.Forms;
using Xamarin.Forms.Platform;
using Xamarin.Forms.Platform.EtoForms;

namespace Xamarin.Forms
{



	public class EtoFormsPlatform : PlatformBase
	{

		protected Eto.Forms.Application EtoApplication { get; set; }



		public EtoFormsPlatform (Eto.Platform platform)
		{
			EtoApplication = new Eto.Forms.Application (platform);
		}

		public override void Init (TargetIdiom idiom)
		{
			SetServices (new EtoServices ());
			UI.Init ();
		}

		public override SizeRequest GetNativeSize (VisualElement view, double widthConstraint, double heightConstraint)
		{
			return new SizeRequest (new Size (view.Width, view.Height), new Size (widthConstraint, heightConstraint));
		}

		public override bool Supports3D {
			get { return false; }
		}

		public void Run (Form form, Application app)
		{
			Forms.Application = app;
			form.SetPage (app.MainPage);
			EtoApplication.MainForm = form;
			EtoApplication.Run ();
		}
	}
}