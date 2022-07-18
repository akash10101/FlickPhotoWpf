using PhotoSearch.Commands;
using PhotoSearch.Models;
using PhotoSearch.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PhotoSearch.ViewModel
{
    public class DisplayPhotosViewModel : ViewModelBase
    {
        public ICommand BackNavigationCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }


        public DisplayPhotosViewModel(NavigationService navigationService)
        {
            BackNavigationCommand = new NavigationCommand(navigationService);
            
        }


    }
}
