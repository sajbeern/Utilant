using System.Collections.Generic;
using UtilantDemo.Services.Photo;
using UtilantDemo.Models;

namespace UtilantDemo.Repository
{
    public class PhotoRepository
    {
        private IPhotoService _photoService;

        public PhotoRepository(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        /// <summary>
        /// This method returns all thumbnails
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PhotoModel> FetchPhotos()
        {
            var photos = _photoService.FetchPhotos();
            return photos;
        }
    }
}