using PhotoSearch.Commands;
using PhotoSearch.Models;
using PhotoSearch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PhotoSearch.ViewModel
{
    public class GetPhotosViewModel : ViewModelBase
    {
        public GetPhotosViewModel(SearchPhotoInformation info, NavigationService DisplayPhotosViewNavigationService)
        {
            SearchCommand = new FetchPhotoCommand(this, info, DisplayPhotosViewNavigationService);
        }

        public Visibility visibility { get; set; }

        private string _searchText;

        public string SearchText  
        {
            get { return _searchText; }
            set { _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public ICommand SearchCommand { get; }

    }
}
