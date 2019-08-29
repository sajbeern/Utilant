using UtilantDemo.Services.Album;
using UtilantDemo.Services.User;
using UtilantDemo.Services.Photo;
using UtilantDemo.Services.Post;

namespace UtilantDemo.Factory
{
    public class FactoryRepository
    {
        public AlbumService AlbumService()
        {
            return new AlbumService();
        }

        public UserService UserService()
        {
            return new UserService();
        }

        public PhotoService PhotoService()
        {
            return new PhotoService();
        }

        public PostService PostService()
        {
            return new PostService();
        }
    }
}