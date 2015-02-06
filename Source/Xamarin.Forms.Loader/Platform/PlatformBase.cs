using System;
using System.IO;
using System.Reflection;

namespace Xamarin.Forms.Platform {

    /// <summary>
    ///
    /// </summary>
    public abstract class PlatformBase : BindableObject, IPlatform, IPlatformEngine {
        private Page root;

        public abstract void Init(TargetIdiom idiom);

        /// <summary>
        /// Sets the root Page of a Xamarin Forms application.
        /// </summary>
        /// <param name="newRoot"></param>
        public void SetPage(Page newRoot) {
            root = newRoot;
            root.BindingContext = BindingContext;
            root.Platform = this;
        }

        public IPlatformEngine Engine {
            get { return this; }
        }

        public Page Page { get; protected set; }

        public abstract SizeRequest GetNativeSize(VisualElement view, double widthConstraint, double heightConstraint);

        public abstract bool Supports3D { get; }

        public void SetServices(PlatformServicesBase services) {
            Device.PlatformServices = services;
            Device.OS = TargetPlatform.Other;
        }
    }
}