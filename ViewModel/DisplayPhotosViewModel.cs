using PhotoSearch.Commands;
using PhotoSearch.Models;
using PhotoSearch.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoSearch.ViewModel
{
    public class DisplayPhotosViewModel : ViewModelBase
    {
        private SearchPhotoInformation _info;
        public ICommand BackNavigationCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ImageSource bckSource { get; }

        private string _searchText;

        private List<ImageInformation> _photoSource;
        private ImageInformation img;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public List<ImageInformation> PhotoSource
        {
            get { return img.GetImageSourceList(_info.photos); }
            set
            {
                _photoSource = value;
                OnPropertyChanged(nameof(PhotoSource));
            }
        }

        public DisplayPhotosViewModel(NavigationService navigationService, SearchPhotoInformation info)
        {
            BackNavigationCommand = new NavigationCommand(navigationService);
            SearchCommand = new SearchPhotosCommand(this, info);
            _info = info;
            img = new ImageInformation();
            bckSource = new BitmapImage(new Uri(Path.GetFullPath(@"..\..\..\Resources\back.png")));
        }
    }
}

