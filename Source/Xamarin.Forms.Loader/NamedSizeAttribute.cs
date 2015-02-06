using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms {
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class NamedSizeAttribute : Attribute {
        public TargetIdiom Idiom { get; protected set; }
        public Type Target { get; protected set; }
        public NamedSize WhenSize { get; protected set; }
        public double IsSize { get; protected set; }
        public NamedSizeAttribute(TargetIdiom idiom, Type target, NamedSize whenSize, double isSize) {
            Idiom = idiom;
            Target = target;
            WhenSize = whenSize;
            IsSize = isSize;
        }
    }
}
