using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using UtilantDemo.Models;
using NLog;

namespace UtilantDemo.Services.User
{
    public class UserService : IUserService
    {
        /// <summary>
        /// This method returns all users details
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserModel> FetchUsers()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            IEnumerable<UserModel> users = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("users");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<UserModel>>();
                    readTask.Wait();

                    users = readTask.Result;
                }
                else
                {
                    //Error response received   
                    users = Enumerable.Empty<UserModel>();
                    logger.Error("Error occured in User service FetchUsers method calling API Server for Users.");
                }
            }
            return users;
        }
    }
}