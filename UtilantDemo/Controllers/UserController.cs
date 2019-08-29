using System;
using System.Web.Mvc;
using UtilantDemo.ViewModels;
using UtilantDemo.Helpers;
using NLog;

namespace UtilantDemo.Controllers
{
    public class UserController : Controller
    {
        private UserPost _userPost;
        private Logger logger;

        public UserController()
        {
            _userPost = new UserPost();
            logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// This method retrieve the user details with his/her posts
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult Details(int userId)
        {
            try
            {
                ViewBag.HasError = false;
                UserViewModel userDetails = _userPost.FetchUserDetailsByUserId(userId);
                return View(userDetails);
            }
            catch (Exception ex)
            {
                ViewBag.HasError = true;
                logger.ErrorException("Error occured in User controller Details Action", ex);
                return View();
            }
        }
    }
}