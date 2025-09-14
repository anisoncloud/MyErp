using Microsoft.AspNetCore.Mvc;

namespace MyErp.Controllers
{
    public class AllApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
