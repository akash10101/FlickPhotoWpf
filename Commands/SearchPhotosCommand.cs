using PhotoSearch.Models;
using PhotoSearch.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace PhotoSearch.Commands
{
    public class SearchPhotosCommand : CommandBase
    {
        private readonly SearchPhotoInformation _photoInfo;
        private readonly DisplayPhotosViewModel _viewModel;
        
        public SearchPhotosCommand(DisplayPhotosViewModel viewModel, SearchPhotoInformation info)
        {
            _viewModel = viewModel;
            _photoInfo = info;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(DisplayPhotosViewModel.SearchText))
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
            _viewModel.PhotoSource = new ImageInformation().GetImageSourceList(_photoInfo.photos);
        }

        public override bool CanExecute(object parameter)
        {
            if (string.IsNullOrEmpty(_viewModel.SearchText))
                return false;
            return base.CanExecute(parameter);
        }
    }
}
