using System.Collections.Generic;
using UtilantDemo.Models;

namespace UtilantDemo.Services.Album
{
    public interface IAlbumService
    {
        IEnumerable<AlbumModel> FetchAlbums();
    }
}
