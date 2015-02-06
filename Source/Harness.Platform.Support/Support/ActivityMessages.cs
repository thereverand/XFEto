using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Support {

    public delegate void MessageHandler(string message);

    public static class ActivityMessage {

        static ActivityMessage() {
            Output = DefaultSendHandler;
            Log = DefaultSendHandler;
            Trace = DefaultSendHandler;
        }

        public static MessageHandler Output { get; set; }

        public static MessageHandler Log { get; set; }

        public static MessageHandler Trace { get; set; }

        private static void DefaultSendHandler(string message) {
        }

        public static void Send(MessageHandler handler, string message, params object[] parameters) {
            handler(string.Format(message, parameters));
        }

        public static void SendAll(string message, params object[] parameters) {
            Send(
                Output +
                Trace +
                Log,
                message,
                parameters
            );
        }
    }
}