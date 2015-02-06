using Eto.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;
using Panel = Eto.Forms.Panel;

[assembly: ExportRenderer(typeof(Frame), typeof(FrameRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class FrameRenderer : ViewRendererBase<Frame, PixelLayout> {
        private readonly PixelLayout layout;
        private Panel top, bottom, left, right;

        //private Drawable drawable;
        private readonly Panel content;

        public FrameRenderer() {
            Control = layout = new PixelLayout();
            content = new Panel();
            //drawable = new Drawable();
            top = new Panel();
            bottom = new Panel();
            left = new Panel();
            right = new Panel();
        }

        private void OnPaddingChange() {
            var size = layout.Bounds;

            if (size.Height < 0 || size.Width < 0) return;

            var width = size.Width - Element.Padding.Right;
            var height = size.Height - Element.Padding.Bottom;

            content.Width = (int)width;
            content.Height = (int)height;

            layout.Move(content, (int)Element.Padding.Left, (int)Element.Padding.Top);
        }

        public override void OnElementChanged() {
            base.OnElementChanged();

            //layout.Add(drawable, 0, 0);

            BindColor(top, Element, c => c.BackgroundColor, Frame.OutlineColorProperty);
            BindColor(bottom, Element, c => c.BackgroundColor, Frame.OutlineColorProperty);
            BindColor(left, Element, c => c.BackgroundColor, Frame.OutlineColorProperty);
            BindColor(right, Element, c => c.BackgroundColor, Frame.OutlineColorProperty);
            layout.Add(content, (int)Element.Padding.Left, (int)Element.Padding.Top);
            layout.Add(top, 0, 0);
            layout.Add(right, 0, 0);
            layout.Add(bottom, 0, 0);
            layout.Add(left, 0, 0);
            Control.LoadComplete += (sender, args) => ResizeFrame();
            Control.SizeChanged += (sender, args) => ResizeFrame();
            Element.OnPropertyChange(Layout.PaddingProperty, ResizeFrame);

            if (Element.Content != null)
                content.SetView(Element.Content);
        }

        private void ResizeFrame() {
            var bounds = NearestDefinedBounds(layout);

            const int leftP = 0;
            const int topP = 0;
            var rightP = (int)(bounds.Right - (Element.Padding.Right));
            var bottomP = (int)(bounds.Bottom - (Element.Padding.Bottom));

            layout.Move(content, (int)Element.Padding.Left, (int)Element.Padding.Top);

            content.Size = new Eto.Drawing.Size(
                (int)(bounds.Width - (Element.Padding.Left + Element.Padding.Right)),
                (int)(bounds.Height - (Element.Padding.Top + Element.Padding.Bottom))
            );

            layout.Move(top, leftP, topP);
            layout.Move(right, rightP, topP);
            layout.Move(bottom, leftP, bottomP);
            layout.Move(left, leftP, topP);

            top.Size = new Eto.Drawing.Size(bounds.Width, (int)Element.Padding.Top);

            right.Size = new Eto.Drawing.Size(
                (int)Element.Padding.Right,
                bounds.Height
            );

            bottom.Size = new Eto.Drawing.Size(
                bounds.Width,
                (int)Element.Padding.Bottom
            );

            left.Size = new Eto.Drawing.Size(
                (int)Element.Padding.Left,
                bounds.Height
            );

            //TODO: FIX Stutter in WPF
            //layout.Invalidate();
            //content.Invalidate();
            //top.Invalidate();
            //right.Invalidate();
            //bottom.Invalidate();
            //left.Invalidate();
        }
    }
}