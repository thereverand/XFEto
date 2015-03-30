using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eto;
using Eto.Forms;
using SampleApp;
using Xamarin.Forms;
using Size = Eto.Drawing.Size;

namespace EtoFormsSample {

    internal class Program {

        [STAThread]
        private static void Main(string[] args) {
            var platform = new EtoFormsPlatform(Platforms.Wpf);
            Forms.Init(platform, TargetIdiom.Desktop);
            var window = new Form { Size = new Size(800, 600) };
            platform.Run(window, new App());
        }
    }
}