using FlickrNet;
using PhotoSearch.Models;
using PhotoSearch.Services;
using PhotoSearch.Store;
using PhotoSearch.ViewModel;

using System.ComponentModel;


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
            var f = new Flickr("3b4a7c41b858850dfa115145f96fdfbf");
            var options = new PhotoSearchOptions
            { Tags = _viewModel.SearchText, PerPage = 20, Page = 1 };
            PhotoCollection photos = f.PhotosSearch(options);
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
