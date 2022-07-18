using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhotoSearch
{
    /// <summary>
    /// Interaction logic for DisplayPhotos.xaml
    /// </summary>
    public partial class DisplayPhotos : UserControl
    {
        public PhotoCollection foto = null;
        public DisplayPhotos()
        {
            InitializeComponent();
            CreateWrapPanel();
            
            
        }

        private void CreateWrapPanel()
        {
            disp.Orientation = Orientation.Horizontal;
            //disp.Width = 400;
            var f = new Flickr("3b4a7c41b858850dfa115145f96fdfbf");
            var options = new PhotoSearchOptions
            { Tags = "Nature", PerPage = 20, Page = 1 };
            PhotoCollection photos = f.PhotosSearch(options);

            foreach(var photo in photos)
            {
                Image img = new Image()
                {
                    Source = new BitmapImage(new Uri(photo.ThumbnailUrl))
                };
                disp.Children.Add(img);
            }
        }
    }
}
