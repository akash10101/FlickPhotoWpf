using NUnit.Framework;
using PhotoSearch.Models;
using PhotoSearch.Services;
using PhotoSearch.Store;
using PhotoSearch.ViewModel;

namespace PhotoSearchUnitTests
{
    [TestFixture]
    public class NavigationServiceUnitTests
    {
        private GetPhotosViewModel modelBase;

        private NavigationService navService;

        public SearchPhotoInformation info;

        private DisplayPhotosViewModel model;

        private NavigationStore navStore;
        public GetPhotosViewModel GetViewModel()
        {
            return modelBase;
        }

        private DisplayPhotosViewModel CreateDisplayPhotosViewModel()
        {
            return model;
        }

        [SetUp]
        public void Setup()
        {
            navStore = new NavigationStore(); 
            navService = new NavigationService(navStore, GetViewModel);
            
            model = new DisplayPhotosViewModel(navService, info);
            modelBase = new GetPhotosViewModel(info, new NavigationService(navStore, CreateDisplayPhotosViewModel)); 
        }

        [Test]
        public void NavigateToOtherView()
        {
            model.BackNavigationCommand.Execute(null);
            Assert.AreEqual("PhotoSearch.ViewModel.GetPhotosViewModel", navStore.CurrentViewModel.ToString());
        }
    }
}
