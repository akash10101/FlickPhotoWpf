using NUnit.Framework;
using PhotoSearch.Models;
using System.Configuration;

namespace PhotoSearchUnitTests
{
    [TestFixture]
    public class SearchPhotoInformationUnitTest
    {
        [Test]
        public void FetchPhotoFromFlickrSuccessfully()
        {
            ConfigurationManager.AppSettings["FlickrAPIKey"] = "3b4a7c41b858850dfa115145f96fdfbf";
            var info = new SearchPhotoInformation();
            var photos = info.GetPhotosFromFlickr("dog");
            Assert.AreNotEqual(0, photos.Count);
        }

        [Test]
        public void FetchPhotoUnsuccessfulWrongAPI()
        {
            ConfigurationManager.AppSettings["FlickrAPIKey"] = "akash";
            var info = new SearchPhotoInformation();
            try
            {
                var photos = info.GetPhotosFromFlickr("dog");
                Assert.Fail();
            }
            catch (FlickrNet.Exceptions.InvalidApiKeyException e)
            {
                Assert.Pass();
            }
        }
    }
}
