using PhotoSearch.Models;
using PhotoSearch.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSearch.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentModel => _store.CurrentViewModel;

        private NavigationStore _store;

        public MainViewModel(NavigationStore store)
        {
            _store = store;
            _store.changed += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModel));
        }
    }
}
