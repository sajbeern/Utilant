using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using NLog;
using UtilantDemo.Helpers;

namespace UtilantDemo.Controllers
{
    public class HomeController : Controller
    {
        private UserAlbum _userAlbum;
        private Logger logger;

        public HomeController()
        {
            _userAlbum = new UserAlbum();
            logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Home page of the application
        /// </summary>
        /// <param name="currentFilter"></param>
        /// <param name="searchText"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Home(string currentFilter, string searchText, int? page)
        {
            try
            {
                ViewBag.Message = "Home page.";
                ViewBag.HasError = false;
                
                //Get the list of titles with first thumnail and user details
                var albums = _userAlbum.GetAlbumList();

                if (searchText != null)
                {
                    page = 1;
                }
                else
                {
                    searchText = currentFilter;
                }

                ViewBag.CurrentFilter = searchText;

                if (!String.IsNullOrEmpty(searchText))
                {
                    albums = albums.Where(a => a.Name.ToUpper().Contains(searchText.ToUpper()) || a.Title.ToUpper().Contains(searchText.ToUpper()));
                }

                int pageSize = 5;
                int pageNumber = (page ?? 1);

                return View(albums.ToPagedList(pageNumber, pageSize));
            }
            catch(Exception ex)
            {
                ViewBag.HasError = true;
                logger.ErrorException("Error occured in Home controller Home Action", ex);
                return View();
            }        
        }
    }
}