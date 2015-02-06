namespace Xamarin.Forms {

    public interface IHandler<out TResult> : IRegisterable {

        Element Source { get; set; }

        TResult Result { get; }
    }
}