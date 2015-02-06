using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Platform.Controllers {

    public class ViewController : VisualElementController, IViewController {

        public static ViewController ForView(View element) {
            return new ViewController(element);
        }

        internal ViewController(IViewController cntrlr)
            : base(cntrlr) {
        }
    }
}