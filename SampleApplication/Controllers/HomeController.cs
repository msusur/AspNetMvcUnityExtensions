using System.Web.Mvc;

namespace SampleApplication.Controllers
{
    public interface IHomeController
    {
        ActionResult Index();
    }

    public class HomeController : Controller, IHomeController
    {
        private readonly IFoo _foo;

        public HomeController(IFoo foo)
        {
            _foo = foo;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
