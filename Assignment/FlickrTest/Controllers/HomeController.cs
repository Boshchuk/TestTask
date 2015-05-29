using System.Web.Mvc;
using FlickrTest.Models;
using FlickrTest.Repository;

namespace FlickrTest.Controllers
{
    /// <summary>
    /// The home controller
    /// </summary>
    public class HomeController : Controller
    {
        private IRepository flickRepository { get; set; }

        public HomeController(IRepository repository)
        {
            this.flickRepository = repository;
        }

        /// <summary>
        /// GET: /Home/
        /// </summary>
        /// <returns>Returns an action result containing the view</returns>
        public ActionResult Index()
        {
            return View();
        }

        
        /// <summary>
        /// Gets images from repository
        /// </summary>
        /// <param name="tags">Tags that should be searched for in the repository</param>
        /// <returns>A Json object containing the images from the repository</returns>
        [HttpPost]
        public ActionResult GetImages(string tags)
        {
            return Json(flickRepository.GetImagesByTags(tags));
        }

        public ActionResult SharedTags(string id)
        {
            var model = new FlickrImagesCollection();

            if (!string.IsNullOrEmpty(id))
            {
                model = flickRepository.GetImagesByTags(id);
            }
            
            return View("SharedTags", model);
        }
    }
}
