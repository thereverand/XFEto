using System;

namespace Xamarin.Forms.Support {

    public class InvalidException : Exception {

        /// <summary>
        /// Creates a new InvalidException for the specified type which is invalid for the specified reason.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="reason"></param>
        public InvalidException(string type, string reason)
            : base(type + " is Invalid : " + reason) {
        }
    }
}