using CompanySalesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanySalesAPI.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService) 
        {
            // Dependency Injeciton
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }


        // TODO:
        /*
        GetCustomerProfile
        - Input: customer_id
        - Output DTO: Full customer profile with demographics, total lifetime sales, average order value
        - Purpose: Showcase DTO composition and joins across dimensions and fact tables
         */

        /*
         GetCustomerGrowthTrend
        - Input: country, start_date, end_date
        - Output DTO: Monthly count of new customers
        - Purpose: Time-series trend analysis
         */

        /*
         GetCustomerSegmentation
        - Input: none or filters
        - Output DTO: Breakdown by marital status, gender, country
        - Purpose: Enum usage + demographic analytics

         */

    }


}
