using System.Collections.Generic;
using UtilantDemo.Models;

namespace UtilantDemo.Services.Photo
{
    public interface IPhotoService
    {
        IEnumerable<PhotoModel> FetchPhotos();
    }
}
