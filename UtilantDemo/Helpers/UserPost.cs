using System.Linq;
using UtilantDemo.Factory;
using UtilantDemo.Repository;
using UtilantDemo.ViewModels;

namespace UtilantDemo.Helpers
{
    public class UserPost
    {
        private FactoryRepository factoryRepository;

        public UserPost()
        {
            factoryRepository = new FactoryRepository();
        }

        /// <summary>
        /// This method returns user details filtered by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserViewModel FetchUserDetailsByUserId(int userId)
        {
            var userSVC = factoryRepository.UserService();
            var userRepo = new UserRepository(userSVC);

            var postSVC = factoryRepository.PostService();
            var postRepo = new PostRepository(postSVC);

            var user = userRepo.FetchUsers().Where(p => p.Id == userId).FirstOrDefault();
            var posts = postRepo.FetchPosts();
            posts = posts.Where(p => p.UserId == userId).ToList();

            var userDetails = new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.Phone,
                Website = user.Website,
                Address = user.Address,
                Company = user.Company,
                Post = posts
            };

            return userDetails;
        }
    }
}