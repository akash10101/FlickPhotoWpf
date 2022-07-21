using PhotoSearch.Commands;
using PhotoSearch.Models;
using PhotoSearch.Services;
using System;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoSearch.ViewModel
{
    public class GetPhotosViewModel : ViewModelBase
    {
        private string _searchText;

        public ICommand SearchCommand { get; }

        public ImageSource bckSource { get; }

        public ImageSource logoSource { get; }

        public ImageSource logoTextSource { get; }

        public GetPhotosViewModel(SearchPhotoInformation info, NavigationService DisplayPhotosViewNavigationService)
        {
            SearchCommand = new FetchPhotoCommand(this, info, DisplayPhotosViewNavigationService);
            bckSource = new BitmapImage(new Uri(Path.GetFullPath(@"..\..\..\Resources\back.png")));
            logoSource = new BitmapImage(new Uri(Path.GetFullPath(@"..\..\..\Resources\Camera-With-Flash-Emoji.png")));
            logoTextSource = new BitmapImage(new Uri(Path.GetFullPath(@"..\..\..\Resources\P.png")));
        }


        public string SearchText  
        {
            get { return _searchText; }
            set
            { 
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }
    }
}