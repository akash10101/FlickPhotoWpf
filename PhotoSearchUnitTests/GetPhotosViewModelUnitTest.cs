using System;
using NUnit.Framework;
using PhotoSearch.Models;
using PhotoSearch.Services;
using PhotoSearch.Store;
using PhotoSearch.ViewModel;

namespace PhotoSearchUnitTests
{
    [TestFixture]
    public class GetPhotosViewModelUnitTest
    {
        public SearchPhotoInformation info;

        private ViewModelBase modelBase;

        private Func<ViewModelBase> func;

        private Moq.Mock<NavigationService> navMock;

        private GetPhotosViewModel view;

        
        
        public ViewModelBase GetViewModel()
        {
            return modelBase;
        }

        [SetUp]
        public void Setup()
        {
            
            modelBase = new ViewModelBase();
            var u = new GetPhotosViewModelUnitTest();
            func = u.GetViewModel;
            navMock = new Moq.Mock<NavigationService>(new NavigationStore(), func);
            view = new GetPhotosViewModel(info, navMock.Object);

        }
        
        [Test]
        public void SearchButtonIsDisabled()
        {
            Assert.AreEqual(false, view.SearchCommand.CanExecute(null));
        }

        [Test]
        public void SearchButtonIsEnabled()
        {
            view.SearchText = "nature";
            Assert.AreEqual(true, view.SearchCommand.CanExecute(null));
        }

    }
}
