using System.Collections.Generic;
using System.Linq;
using UtilantDemo.Factory;
using UtilantDemo.Repository;
using UtilantDemo.ViewModels;
using UtilantDemo.Models;

namespace UtilantDemo.Helpers
{
    public class AlbumThumbnail
    {
        private FactoryRepository factoryRepository;

        public AlbumThumbnail()
        {
            factoryRepository = new FactoryRepository();
        }

        /// <summary>
        /// This method returns user details filtered by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public PhotoViewModel FetchPhotosByAlbumId(int albumId)
        {
            var albumSVC = factoryRepository.AlbumService();
            var albumRepo = new AlbumRepository(albumSVC);

            var photoSVC = factoryRepository.PhotoService();
            var photoRepo = new PhotoRepository(photoSVC);

            PhotoViewModel photoList = null;
            IEnumerable<PhotoModel> photos = null;
            AlbumModel album = null;

            album = albumRepo.FetchAlbums().Where(a => a.Id == albumId).FirstOrDefault();
            photos = photoRepo.FetchPhotos();
            photos = photos.Where(p => p.AlbumId == albumId).ToList();

            photoList = new PhotoViewModel()
            {
                AlbumId = album.Id,
                Title = album.Title,
                Photo = photos
            };
            return photoList;
        }
    }
}