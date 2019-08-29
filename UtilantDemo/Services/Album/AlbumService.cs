using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using UtilantDemo.Models;
using NLog;

namespace UtilantDemo.Services.Album
{
    public class AlbumService : IAlbumService
    {
        /// <summary>
        /// This method returns all album details
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AlbumModel> FetchAlbums()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            IEnumerable<AlbumModel> albums = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("albums");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AlbumModel>>();
                    readTask.Wait();

                    albums = readTask.Result;
                }
                else
                {
                    //Error response received   
                    albums = Enumerable.Empty<AlbumModel>();
                    logger.Error("Error occured in Album service FetchAlbum method calling API Server for Album.");
                }
            }
            return albums;
        }
    }
}