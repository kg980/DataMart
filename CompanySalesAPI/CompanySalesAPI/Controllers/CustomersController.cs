using Microsoft.AspNetCore.Mvc;

namespace CompanySalesAPI.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
