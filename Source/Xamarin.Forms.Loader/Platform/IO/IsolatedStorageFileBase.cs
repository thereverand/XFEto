using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace Xamarin.Forms.Platform {

    public abstract class IsolatedStorageFileBase : IIsolatedStorageFile {

        public abstract Task CreateDirectoryAsync(string path);

        public abstract Task<bool> GetDirectoryExistsAsync(string path);

        public abstract Task<bool> GetFileExistsAsync(string path);

        public abstract Task<DateTimeOffset> GetLastWriteTimeAsync(string path);

        public abstract Task<System.IO.Stream> OpenFileAsync(
            string path,
            FileMode mode,
            FileAccess access,
            FileShare share);

        public abstract Task<System.IO.Stream> OpenFileAsync(
            string path,
            FileMode mode,
            FileAccess access);

        Task<System.IO.Stream> Xamarin.Forms.IIsolatedStorageFile.OpenFileAsync(
            string path,
            Xamarin.Forms.FileMode mode,
            Xamarin.Forms.FileAccess access,
            Xamarin.Forms.FileShare share) {
            return OpenFileAsync(path, (FileMode)mode, (FileAccess)access, (FileShare)share);
        }

        Task<System.IO.Stream> Xamarin.Forms.IIsolatedStorageFile.OpenFileAsync(string path, Xamarin.Forms.FileMode mode, Xamarin.Forms.FileAccess access) {
            return OpenFileAsync(path, (FileMode)mode, (FileAccess)access);
        }
    }
}