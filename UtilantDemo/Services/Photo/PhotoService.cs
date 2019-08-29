using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using UtilantDemo.Models;
using NLog;

namespace UtilantDemo.Services.Photo
{
    public class PhotoService : IPhotoService
    {
        /// <summary>
        /// This method returns all thumbnails
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PhotoModel> FetchPhotos()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            IEnumerable<PhotoModel> photos = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("photos");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PhotoModel>>();
                    readTask.Wait();

                    photos = readTask.Result;
                }
                else
                {
                    //Error response received   
                    photos = Enumerable.Empty<PhotoModel>();
                    logger.Error("Error occured in Photo service FetchPhotos method calling API Server for Photos.");
                }
            }
            return photos;
        }
    }
}