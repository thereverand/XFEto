using System;
using Xamarin.Forms.Platform.Handlers;

namespace Xamarin.Forms {

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class ExportRendererAttribute : HandlerAttribute {

        public ExportRendererAttribute(Type viewType, Type rendererType)
            : base(viewType, rendererType) {
            //Are these parameter names backwards or it me?
            //This matches the parameter order used by iOS and Android.
            //But they are labeled handler and target, in that order;
            //when the first is a control type and the second is a renderer type?
        }
    }

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class ExportWebViewSourceHandler : HandlerAttribute {

        public ExportWebViewSourceHandler(Type handler)
            : base(typeof(WebViewSource), handler) {
        }
    }
}