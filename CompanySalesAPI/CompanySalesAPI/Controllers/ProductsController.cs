using CompanySalesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanySalesAPI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {   // DI
            _productService = productService;
        }


        public IActionResult Index()
        {
            return View();
        }

        // TODO:
        /*
         GetProductPerformance
        - Input: product_id
        - Output DTO: Total sales, quantity sold, average price, maintenance status
        - Purpose: Join fact_sales with dim_products, showcase calculated field
         */


        /*
         GetTopProducts
        - Input: category, date range
        - Output DTO: Top N products by revenue or quantity
        - Purpose: Aggregation + filtering + DTO projectio
         */


        /*
         GetCategoryBreakdown
        - Input: none or product_line
        - Output DTO: Sales grouped by category/subcategory
        - Purpose: Enum + string grouping + business insight
         */


        /*
         GetProductLifecycle
        - Input: product_id
        - Output DTO: Start date, first sale date, last sale date
        - Purpose: Time-based analysis + joins
         */

    }
}
