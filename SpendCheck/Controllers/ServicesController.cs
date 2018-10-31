using CustomerManagementSys.Models;
using System.Web.Mvc;

namespace SpendCheck.Controllers
{
    public class ServicesController : Controller
    {
        private ApplicationDbContext _context;

        public ServicesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View("NewServiceForm");
        }
    }
}
