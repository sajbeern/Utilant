using System.Collections.Generic;
using System.Linq;
using UtilantDemo.Factory;
using UtilantDemo.Repository;
using UtilantDemo.ViewModels;
using UtilantDemo.Models;

namespace UtilantDemo.Helpers
{
    public class UserAlbum
    {
        private FactoryRepository factoryRepository;

        public UserAlbum()
        {
            factoryRepository = new FactoryRepository();
        }

        /// <summary>
        /// This method returns all details like First thumbnail of album, Title, user's details to show in Home page
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AlbumViewModel> GetAlbumList()
        {
            var albumSVC = factoryRepository.AlbumService();
            var albumRepo = new AlbumRepository(albumSVC);

            var userSVC = factoryRepository.UserService();
            var userRepo = new UserRepository(userSVC);

            var photoSVC = factoryRepository.PhotoService();
            var photoRepo = new PhotoRepository(photoSVC);

            List<AlbumViewModel> albumList = new List<AlbumViewModel>();
            IEnumerable<UserModel> users = null;
            IEnumerable<AlbumModel> albums = null;
            IEnumerable<PhotoModel> photos = null;

            //Get Titles from API
            albums = albumRepo.FetchAlbums();

            //Get User details from API
            users = userRepo.FetchUsers();

            //Get Thumbnails from API
            photos = photoRepo.FetchPhotos();

            albumList = (from album in albums
                         from user in users.Where(u => u.Id == album.UserId)
                         from photo in photos.Where(p => p.AlbumId == album.Id)
                                             .Take(1)
                                             .DefaultIfEmpty()
                         select new AlbumViewModel
                         {
                             Id = album.Id,
                             UserId = user.Id,
                             Title = album.Title,
                             Name = user.Name,
                             Email = user.Email,
                             Phone = user.Phone,
                             Address = user.Address,
                             ThumbnailUrl = photo.ThumbnailUrl
                         }).ToList();

            return albumList;
        }
    }
}