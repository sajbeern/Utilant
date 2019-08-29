using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using UtilantDemo.Models;
using NLog;

namespace UtilantDemo.Services.Post
{
    public class PostService : IPostService
    {
        /// <summary>
        /// This method returns all posts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PostModel> FetchPosts()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            IEnumerable<PostModel> posts = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("posts");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PostModel>>();
                    readTask.Wait();

                    posts = readTask.Result;
                }
                else
                {
                    //Error response received   
                    posts = Enumerable.Empty<PostModel>();
                    logger.Error("Error occured in Post service FetchPosts method calling API Server for posts.");
                }
            }
            return posts;
        }
    }
}