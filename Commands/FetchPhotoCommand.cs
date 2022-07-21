using PhotoSearch.Models;
using PhotoSearch.Services;
using PhotoSearch.ViewModel;

using System.ComponentModel;
using System.Windows;

namespace PhotoSearch.Commands
{
    public class FetchPhotoCommand : CommandBase
    {
        private readonly SearchPhotoInformation _photoInfo;
        private readonly GetPhotosViewModel _viewModel;
        private readonly NavigationService _navigationService;
        public FetchPhotoCommand(GetPhotosViewModel viewModel, SearchPhotoInformation info, NavigationService DisplayPhotoNavigationServie )
        {
            _viewModel = viewModel;
            _photoInfo = info;
            _navigationService = DisplayPhotoNavigationServie;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(GetPhotosViewModel.SearchText))
            {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object parameter)
        {
            _photoInfo.searchText = _viewModel.SearchText;

            _photoInfo.photos = _photoInfo.GetPhotosFromFlickr(_viewModel.SearchText);
            if (_photoInfo.photos.Count == 0)
                MessageBox.Show("No images found. Please search again");

            _navigationService.Navigate();
        }

        public override bool CanExecute(object parameter)
        {
            if (string.IsNullOrEmpty(_viewModel.SearchText))
                return false;
            return base.CanExecute(parameter);
        }
    }
}
