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
        public ActionResult BorrowedBooks()
        {
            var userId = repo.getUserId(System.Web.HttpContext.Current.User.Identity.Name);
            return View(repo.GetMyBorrowedBooks(userId));
        }
    }
}