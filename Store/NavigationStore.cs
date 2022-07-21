using PhotoSearch.ViewModel;
using System;

namespace PhotoSearch.Store
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        public event Action changed;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            changed?.Invoke();
        }
    }
}
