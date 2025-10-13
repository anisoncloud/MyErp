using Microsoft.AspNetCore.Mvc;

namespace MyErp.Controllers
{
    public class DebitVoucherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View ();
        }
    }
}
