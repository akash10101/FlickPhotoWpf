using PhotoSearch.Models;
using PhotoSearch.Services;
using PhotoSearch.Store;
using PhotoSearch.ViewModel;
using System.Windows;

namespace PhotoSearch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public SearchPhotoInformation infoSearch;
        public NavigationStore store;
        private GetPhotosViewModel getModel;
        private DisplayPhotosViewModel displayModel;

        public App()
        {
            infoSearch = new SearchPhotoInformation();
            store = new NavigationStore();
            getModel = new GetPhotosViewModel(infoSearch, new NavigationService(store, CreateDisplayPhotosViewModel));
            displayModel = new DisplayPhotosViewModel(new NavigationService(store, CreateGetPhotosViewModel), infoSearch);
        } 

        protected override void OnStartup(StartupEventArgs e)
        {
            store.CurrentViewModel = CreateGetPhotosViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(store),
                ResizeMode = ResizeMode.NoResize
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private GetPhotosViewModel CreateGetPhotosViewModel()
        {
            return getModel;
        }

        private DisplayPhotosViewModel CreateDisplayPhotosViewModel()
        {
            return displayModel;
        }
    }
}
