using FlickrNet;
using System.Configuration;
using System.Windows;

namespace PhotoSearch.Models
{
    public class SearchPhotoInformation
    {
        public string searchText { get; set; }
        public PhotoCollection photos { get; set; }

        private string _apiKey;

        public SearchPhotoInformation()
        {
            _apiKey = ConfigurationManager.AppSettings["FlickrAPIKey"];
        }

        public PhotoCollection GetPhotosFromFlickr(string searchText)
        {
            var f = new Flickr(_apiKey);
            var options = new PhotoSearchOptions
            { Tags = searchText, PerPage = 16, Page = 1 };
            try
            {
                return f.PhotosSearch(options);
            }
            catch(ApiKeyRequiredException e)
            {
                MessageBox.Show("Flickr API is required to proceed."+ e.Message);
                throw new ApiKeyRequiredException();
            }           
        }
    }
}
