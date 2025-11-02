using Microsoft.AspNetCore.Mvc;

namespace CompanySalesAPI.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
