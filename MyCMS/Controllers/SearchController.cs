using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCMS.Controllers
{
    public class SearchController : Controller
    {
        private IPageRepository pageRepository;
        MyCMSContext db = new MyCMSContext();
        public SearchController()
        {
            pageRepository = new PageRepository(db);
        }
        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.name = q;
            return View(pageRepository.SearchPages(q));
        }
    }
}