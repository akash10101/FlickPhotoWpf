using PhotoSearch.Models;
using PhotoSearch.Services;
using PhotoSearch.Store;
using PhotoSearch.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoSearch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public SearchPhotoInformation infoSearch = new SearchPhotoInformation();
        public NavigationStore store = new NavigationStore();
        protected override void OnStartup(StartupEventArgs e)
        {
            store.CurrentViewModel = CreateGetPhotosViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(store)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private GetPhotosViewModel CreateGetPhotosViewModel()
        {
            return new GetPhotosViewModel(infoSearch, new NavigationService(store, CreateDisplayPhotosViewModel));
        }

        private DisplayPhotosViewModel CreateDisplayPhotosViewModel()
        {
            return new DisplayPhotosViewModel(new NavigationService(store, CreateGetPhotosViewModel));
        }
    }
}
