using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilantDemo.Models
{
    public class PhotoModel
    {
        public int AlbumId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}