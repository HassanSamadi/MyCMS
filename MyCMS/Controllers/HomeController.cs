using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCMS.Controllers
{
    public class HomeController : Controller
    {
        MyCMSContext db = new MyCMSContext();
        private IPageRepository pageRepository;
        public HomeController()
        {
            pageRepository = new PageRepository(db);
        }

        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult Slider()
        {
            return PartialView(pageRepository.PagesInSlider());
        }

    }
}