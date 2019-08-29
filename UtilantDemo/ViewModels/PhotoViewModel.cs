using System.Collections.Generic;
using UtilantDemo.Models;

namespace UtilantDemo.ViewModels
{
    public class PhotoViewModel
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public IEnumerable<PhotoModel> Photo { get; set; }

        public PhotoViewModel()
        {
            Photo = new List<PhotoModel>();
        }
    }
}