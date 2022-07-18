using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSearch.Models
{
    public class SearchPhotoInformation
    {
        public string searchText { get; set; }
        public PhotoCollection photos { get; set; }
    }
}
