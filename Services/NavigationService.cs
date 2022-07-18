using PhotoSearch.Store;
using PhotoSearch.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSearch.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _store;
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> view)
        {
            _store = navigationStore;
            _createViewModel = view;
        }
        public void Navigate()
        {
            _store.CurrentViewModel = _createViewModel();
        }
    }
}
