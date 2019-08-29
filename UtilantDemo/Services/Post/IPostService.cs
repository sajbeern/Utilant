using System.Collections.Generic;
using UtilantDemo.Models;

namespace UtilantDemo.Services.Post
{
    public interface IPostService
    {
        IEnumerable<PostModel> FetchPosts();
    }
}
