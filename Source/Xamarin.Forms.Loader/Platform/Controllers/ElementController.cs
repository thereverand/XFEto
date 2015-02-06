namespace Xamarin.Forms.Platform.Controllers {

    public class ElementController : IElementController {

        public static ElementController ForElement(Element element) {
            return new ElementController(element);
        }

        private readonly IElementController controller;

        internal ElementController(IElementController cntrlr) {
            controller = cntrlr;
        }

        public void SetValueFromRenderer(BindableProperty property, object value) {
            controller.SetValueFromRenderer(property, value);
        }

        public void SetValueFromRenderer(BindablePropertyKey propertyKey, object value) {
            controller.SetValueFromRenderer(propertyKey, value);
        }
    }
}