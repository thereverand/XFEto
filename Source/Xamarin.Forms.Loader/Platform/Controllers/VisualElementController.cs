namespace Xamarin.Forms.Platform.Controllers {

    public class VisualElementController : ElementController, IVisualElementController {
        private readonly IVisualElementController controller;

        public static VisualElementController ForElement(VisualElement element) {
            return new VisualElementController(element);
        }

        internal VisualElementController(IVisualElementController cntrlr)
            : base(cntrlr) {
            controller = cntrlr;
        }

        public void NativeSizeChanged() {
            controller.NativeSizeChanged();
        }
    }
}