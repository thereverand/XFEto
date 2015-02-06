namespace Xamarin.Forms.Platform.Controllers {

    public class ButtonController : ViewController, IButtonController {
        private readonly IButtonController controller;

        public static ButtonController ForButton(Button button) {
            return new ButtonController(button);
        }

        internal ButtonController(IButtonController cntrlr)
            : base(cntrlr) {
            controller = cntrlr;
        }

        public void SendClicked() {
            controller.SendClicked();
        }
    }
}