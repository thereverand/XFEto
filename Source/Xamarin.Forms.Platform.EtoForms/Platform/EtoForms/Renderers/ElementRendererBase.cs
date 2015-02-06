using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Eto;
using Eto.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Controllers;
using Xamarin.Forms.Platform.EtoForms.Renderers;
using Xamarin.Forms.Platform.Renderers;
using Xamarin.Forms.Support;

[assembly: ExportRenderer(typeof(Element), typeof(ElementRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public abstract class ElementRendererBase<TElement, TControl> :
        IElementRenderer<TElement, TControl, ElementController>,

        IBindingContainer
        where TElement : Element
        where TControl : Eto.Forms.Control {

        public IList<IEtoBinding> Bindings { get; private set; }

        protected ElementRendererBase() {
            Bindings = new List<IEtoBinding>();
        }

        #region Element / Control Changes

        public virtual void Clear() {
        }

        public virtual void OnElementChanging(Element val) {
            Bindings.Clear();
            //The Engine.ControlProperty attached property always contains the root Control of the renderer.
            //Remove it from the old.
            if (element != null) {
                Element.SetValue(Renderer.ControlProperty, null);
            }
        }

        public virtual void OnElementChanged() {
            //Control.DataContext = Element;
            //Add it to the new.
            if (Element != null) {
                Controller = new ElementController(Element);
                Element.SetValue(Renderer.ControlProperty, Control);
            }
        }

        public virtual void OnControlChanging(TControl newControl) {
        }

        public virtual void OnControlChanged() {
        }

        #endregion Element / Control Changes

        #region Renderer Properties

        private TElement element;

        public TElement Element {
            get { return element; }
            set {
                OnElementChanging(value);
                element = value;
                OnElementChanged();
            }
        }

        private TControl control;

        public TControl Control {
            get { return control; }
            set {
                OnControlChanging(value);
                control = value;
                OnControlChanged();
            }
        }

        public ElementController Controller { get; private set; }

        #endregion Renderer Properties

        #region Binding

        private EtoBinding<T> ApplyBinding<T>(
            EtoBinding<T> binding
        ) {
            binding.ApplyBinding(this);
            return binding;
        }

        private static EtoBinding<T> Bind<T>
           (
            Control control,
            Element element,
            string controlProperty,
            string elementProperty
        ) {
            return new EtoBinding<T> {
                Control = control,
                Element = element,
                ControlBinding = new PropertyBinding<T>(controlProperty),
                ElementBinding = new PropertyBinding<T>(elementProperty)
            };
        }

        private static EtoBinding<T> Bind<T>(
            Control control,
            Element element,
            string controlProperty,
            BindableProperty property,
            Func<TElement, T> getFromModel,
            Action<TElement, T> setToModel
        ) {
            return new EtoBinding<T> {
                Control = control,
                Element = element,
                ControlBinding = new PropertyBinding<T>(controlProperty),
                ElementBinding = new DelegateBinding<TElement, T>(
                    getFromModel,
                    setToModel,
                    property.PropertyName
                )
            };
        }

        protected EtoBinding<T> Bind<TCntrl, TElem, T>(
            TCntrl cntrl,
            TElem elem,
            Expression<Func<TCntrl, T>> controlProperty,
            BindableProperty modelProperty
        )
            where TCntrl : Eto.Forms.Control
            where TElem : Element {
            var member = Expressions.MemberExpressionToMember(controlProperty);

            var binding = Bind<T>(
                              cntrl,
                              elem,
                              member.Name,
                              modelProperty.PropertyName);

            return ApplyBinding<T>(binding);
        }

        protected EtoBinding<T> Bind<TCntrl, TElem, T>(
            TCntrl control,
            TElem element,
            Expression<Func<TControl, T>> controlProperty,
            Expression<Func<TElem, T>> elementProperty
        )
            where TCntrl : Eto.Forms.Control
            where TElem : Element {
            var cMember = Expressions.MemberExpressionToMember(controlProperty);
            var eMember = Expressions.MemberExpressionToMember(elementProperty);

            var binding = Bind<T>(
                              control,
                              element,
                              cMember.Name,
                              eMember.Name
                          );

            return ApplyBinding<T>(binding);
        }

        protected EtoBinding<TControlType> Bind<TCntrl, TElem, TControlType, TModelType>(
            TCntrl control,
            TElem element,
            Expression<Func<TCntrl, TControlType>> controlProperty,
            BindableProperty modelProperty,
            Func<TModelType, TControlType> toControl,
            Func<TControlType, TModelType> toModel
        )
            where TCntrl : Eto.Forms.Control
            where TElem : Element {
            var member = Expressions.MemberExpressionToMember(controlProperty);

            var binding =
                Bind(
                    control,
                    element,
                    member.Name,
                    modelProperty,
                    c => toControl((TModelType)c.GetValue(modelProperty)),
                    (c, v) => {
                        if (modelProperty.ReturnType.IsAssignableFrom(typeof(TModelType)))
                            c.SetValue(modelProperty, toModel(v));
                    });
            return ApplyBinding<TControlType>(binding);
        }

        #endregion Binding

        #region Binding Specific Types

        protected EtoBinding<Eto.Drawing.Color> BindColor<TCntrl, TElem>(
            TCntrl control,
            TElem element,
            Expression<Func<TCntrl, Eto.Drawing.Color>> controlProperty,
            BindableProperty modelProperty)
            where TCntrl : Eto.Forms.Control
            where TElem : Element {
            return Bind(
                control,
                element,
                controlProperty,
                modelProperty,
                Color,
                Color
            );
        }

        protected EtoBinding<Eto.Drawing.Padding> BindThickness<TCntrl, TElem>(
            TCntrl control,
            TElem element,
            Expression<Func<TCntrl, Eto.Drawing.Padding>> controlProperty,
            BindableProperty modelProperty)
            where TCntrl : Eto.Forms.Control
            where TElem : Element {
            return Bind(
                control,
                element,
                controlProperty,
                modelProperty,
                Padding,
                Thickness
            );
        }

        #endregion Binding Specific Types

        #region Conversions

        protected static Color Color(Eto.Drawing.Color c) {
            return new Color(c.R, c.G, c.B, c.A);
        }

        protected static Eto.Drawing.Color Color(Color c) {
            if (Eto.Forms.Application.Instance.Platform.IsWinForms)
                return new Eto.Drawing.Color((float)c.R, (float)c.G, (float)c.B);
            return new
                Eto.Drawing.Color(
                (float)c.R,
                (float)c.G,
                (float)c.B,
                (float)c.A
            );
        }

        protected static Eto.Drawing.Padding Padding(Thickness thickness) {
            return new Eto.Drawing.Padding(
                (int)thickness.Left,
                (int)thickness.Top,
                (int)thickness.Right,
                (int)thickness.Bottom);
        }

        protected static Thickness Thickness(Eto.Drawing.Padding c) {
            return new Thickness(
                c.Left,
                c.Top,
                c.Right,
                c.Bottom);
        }

        #endregion Conversions

        #region Eto Utilities

        /// <summary>
        /// Locates the nearest ancestor of the specified control with a completely defined Bounds property (neither height no width is -1).
        /// </summary>
        /// <param name="control">The control</param>
        /// <returns></returns>
        protected static Eto.Drawing.Rectangle NearestDefinedBounds(Control control) {
            while (control != null) {
                var bounds = control.Bounds;
                if (bounds.Width != -1 && bounds.Height != -1)
                    return bounds;

                control = control.Parent;
            }

            throw new InvalidOperationException(
                "Defined bounds could not be found."
            );
        }

        #endregion Eto Utilities

        Element IHandler<TControl>.Source { get { return Element; } set { Element = (TElement)value; } }

        TControl IHandler<TControl>.Result { get { return Control; } }
    }
}