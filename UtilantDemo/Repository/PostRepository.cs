using System.Collections.Generic;
using UtilantDemo.Services.Post;
using UtilantDemo.Models;

namespace UtilantDemo.Repository
{
    public class PostRepository
    {
        private IPostService _postService;

        public PostRepository(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// This method returns all posts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PostModel> FetchPosts()
        {
            var posts = _postService.FetchPosts();
            return posts;
        }
    }
}