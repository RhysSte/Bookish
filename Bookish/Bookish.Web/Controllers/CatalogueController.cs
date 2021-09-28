using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.DataAccess;

namespace Bookish.Web.Controllers
{
    public class CatalogueController : Controller
    {

        private BookishRepository repo = new BookishRepository();

        public ActionResult Index()
        {
            return View(repo.GetAllBooks());
        }
    }
}