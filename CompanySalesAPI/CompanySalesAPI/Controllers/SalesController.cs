using Microsoft.AspNetCore.Mvc;

namespace CompanySalesAPI.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
