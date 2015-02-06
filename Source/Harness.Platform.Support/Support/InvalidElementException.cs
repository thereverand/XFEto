using System;

namespace Xamarin.Forms.Support {

    public class InvalidElementException : Exception {

        public InvalidElementException(string elementName, string reason)
            : base(elementName + " is invalid : " + reason) { }
    }
}