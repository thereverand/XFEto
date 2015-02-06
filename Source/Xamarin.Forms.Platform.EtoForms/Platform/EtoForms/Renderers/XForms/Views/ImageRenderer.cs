using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Eto.Drawing;
using Xamarin.Forms;
using Xamarin.Forms.Platform.EtoForms.Renderers;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Image), typeof(ImageRenderer))]

namespace Xamarin.Forms.Platform.EtoForms.Renderers {

    public class ImageRenderer : ViewRendererBase<Image, Eto.Forms.ImageView> {

        public ImageRenderer() {
            Control = new Eto.Forms.ImageView();
        }

        public override void OnElementChanged() {
            base.OnElementChanged();

            Bind(
                Control,
                Element,
                c => c.Image,
                Image.SourceProperty,
                ImageFromImageSource,
                ImageSourceFromImage);
        }

        protected Eto.Drawing.Image StringToImage(string strng) {
            var converter = new ImageConverter();
            return (Eto.Drawing.Image)converter.ConvertFromString(strng);
        }

        protected Eto.Drawing.Image StreamToImage(Func<CancellationToken, Task<Stream>> streamSource) {
            var token = new CancellationToken();
            var stream = streamSource(token).Result;
            if (stream == null || token.IsCancellationRequested) return default(Eto.Drawing.Image);
            var reader = new BinaryReader(stream);
            var bytes = reader.ReadBytes((int)stream.Length);
            return new Bitmap(bytes);
        }

        protected ImageSource ImageSourceFromImage(Eto.Drawing.Image image) {
            var bitmap = ((Bitmap)image);
            return new StreamImageSource() {
                Stream =
                    c =>
                        Task.FromResult(
                    (Stream)new MemoryStream(
                        bitmap.ToByteArray(ImageFormat.Png)
                    ))
            };
        }

        protected Eto.Drawing.Image ImageFromImageSource(ImageSource source) {
            var file = source as FileImageSource;
            var stream = source as StreamImageSource;
            var uri = source as UriImageSource;

            if (file != null) {
                return StringToImage(file.File);
            } else if (stream != null) {
                return StreamToImage(stream.Stream);
            } else if (uri != null) {
                var http = new HttpClient();
                var str = http.GetStreamAsync(uri.Uri).Result;
                return StreamToImage((c) => Task.FromResult(str));
            }
            return default(Eto.Drawing.Image);
        }
    }
}