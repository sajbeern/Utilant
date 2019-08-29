using System;
using System.Web.Mvc;
using UtilantDemo.ViewModels;
using UtilantDemo.Helpers;
using NLog;

namespace UtilantDemo.Controllers
{
    public class ThumbnailController : Controller
    {
        private AlbumThumbnail _albumThumbnail;
        private Logger logger;

        public ThumbnailController()
        {
            _albumThumbnail = new AlbumThumbnail();
            logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// This method retrieve the all thumbnails of particular title
        /// </summary>
        /// <param name="titleId"></param>
        /// <returns></returns>
        public ActionResult Details(int titleId)
        {    
            try
            {
                ViewBag.HasError = false;
                PhotoViewModel photos = _albumThumbnail.FetchPhotosByAlbumId(titleId);
                return View(photos);
            }
            catch (Exception ex)
            {
                ViewBag.HasError = true;
                logger.ErrorException("Error occured in Thumbnail controller Details Action", ex);
                return View();
            }
        }
    }
}