using System.Collections.Generic;
using UtilantDemo.Services.Album;
using UtilantDemo.Models;

namespace UtilantDemo.Repository
{
    public class AlbumRepository
    {
        private IAlbumService _albumService;
        public AlbumRepository(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        /// <summary>
        /// This method retrieves all album list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AlbumModel> FetchAlbums()
        {
            var albums = _albumService.FetchAlbums();
            return albums;
        }
    }
}