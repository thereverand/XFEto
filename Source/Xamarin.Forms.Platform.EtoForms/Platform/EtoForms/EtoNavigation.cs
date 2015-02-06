using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xamarin.Forms.Platform.EtoForms {

    internal class EtoNavigation : INavigation {

        private List<Page> ModalStack { get; set; }

        private List<Page> NavigationStack { get; set; }

        public EtoNavigation() {
        }

        public void RemovePage(Page page) {
            throw new NotImplementedException();
        }

        public void InsertPageBefore(Page page, Page before) {
            throw new NotImplementedException();
        }

        public Task PushAsync(Page page) {
            throw new NotImplementedException();
        }

        public Task<Page> PopAsync() {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync() {
            throw new NotImplementedException();
        }

        public Task PushModalAsync(Page page) {
            throw new NotImplementedException();
        }

        public Task<Page> PopModalAsync() {
            throw new NotImplementedException();
        }

        public Task PushAsync(Page page, bool animated) {
            throw new NotImplementedException();
        }

        public Task<Page> PopAsync(bool animated) {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync(bool animated) {
            throw new NotImplementedException();
        }

        public Task PushModalAsync(Page page, bool animated) {
            throw new NotImplementedException();
        }

        public Task<Page> PopModalAsync(bool animated) {
            throw new NotImplementedException();
        }

        IReadOnlyList<Page> INavigation.NavigationStack {
            get { throw new NotImplementedException(); }
        }

        IReadOnlyList<Page> INavigation.ModalStack {
            get { throw new NotImplementedException(); }
        }
    }
}