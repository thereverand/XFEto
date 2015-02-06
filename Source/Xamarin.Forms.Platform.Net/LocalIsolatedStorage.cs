using System;
using System.IO.IsolatedStorage;
using System.Threading.Tasks;

namespace Xamarin.Forms.Platform.Net {

    public class LocalIsolatedStorage : IsolatedStorageFileBase {

        public static IsolatedStorageFileBase Create() {
            const IsolatedStorageScope scope = IsolatedStorageScope.User | IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain;
            var isolatedStorage = System.IO.IsolatedStorage.IsolatedStorageFile.GetStore(scope, null, null);
            return new LocalIsolatedStorage(isolatedStorage);
        }

        private System.IO.IsolatedStorage.IsolatedStorageFile file;

        public LocalIsolatedStorage(System.IO.IsolatedStorage.IsolatedStorageFile file) {
            this.file = file;
        }

        public override Task CreateDirectoryAsync(string path) {
            return Task.Factory.StartNew(() => file.CreateDirectory(path));
        }

        public override Task<bool> GetDirectoryExistsAsync(string path) {
            return Task<bool>.Factory.StartNew(() => file.DirectoryExists(path));
        }

        public override Task<bool> GetFileExistsAsync(string path) {
            return Task<bool>.Factory.StartNew(() => file.FileExists(path));
        }

        public override Task<DateTimeOffset> GetLastWriteTimeAsync(string path) {
            return Task<DateTimeOffset>.Factory.StartNew(() => (file.GetLastWriteTime(path)));
        }

        public override Task<System.IO.Stream> OpenFileAsync(string path, FileMode mode, FileAccess access, FileShare share) {
            return Task<System.IO.Stream>.Factory.StartNew(() => (System.IO.Stream)file.OpenFile(path, (System.IO.FileMode)mode, (System.IO.FileAccess)access, (System.IO.FileShare)share));
        }

        public override Task<System.IO.Stream> OpenFileAsync(string path, FileMode mode, FileAccess access) {
            return Task<System.IO.Stream>.Factory.StartNew(() => (System.IO.Stream)file.OpenFile(path, (System.IO.FileMode)mode, (System.IO.FileAccess)access));
        }
    }
}