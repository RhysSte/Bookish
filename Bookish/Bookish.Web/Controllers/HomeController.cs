using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.DataAccess;

namespace Bookish.Web.Controllers
{
    public class HomeController : Controller
    {
        private BookishRepository repo = new BookishRepository();
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

        public ActionResult Catalogue()
        {
            ViewBag.Message = "Library Catalogue";

            var allBooks = repo.GetAllBooks();

            return View(allBooks);
        }
    }
}