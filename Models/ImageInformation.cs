using FlickrNet;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoSearch.Models
{
    public class ImageInformation
    {
        public ImageSource source { get; set; }


        public List<ImageInformation> GetImageSourceList(PhotoCollection ph)
        {
            var list = new List<ImageInformation>();
            foreach (var photo in ph)
            {

                if (photo.MediumUrl != null)
                    list.Add(new ImageInformation()
                    {
                        source = new BitmapImage(new Uri(photo.MediumUrl))
                        
                    });

            }
            return list;
        }
    }
}
