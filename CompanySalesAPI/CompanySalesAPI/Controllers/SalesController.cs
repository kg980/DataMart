using CompanySalesAPI.Models.DTOs;
using CompanySalesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanySalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {

        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {   // DI
            _salesService = salesService;
        }

        /*
        GetTopCustomersBySales
        - Input: optional filters (e.g., country, date range)
        - Output DTO: List of top N customers by sales amount
        - Purpose: Business insight + aggregation + filterin
         */


        [HttpGet("top-customers")]  // FromQuery allows person to specify a count, or it defaults to 10, e.g. 'GET /api/sales/top-customers?count=5'
        public async Task<ActionResult<List<TopCustomerDto>>> GetTopCustomers([FromQuery] int count = 10)
        {
            var result = await _salesService.GetTopCustomersAsync(count);
            return Ok(result);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //TODO:

        /*
         GetTotalSales
        - Input: start_date, end_date
        - Output DTO: Total revenue, total quantity, average order value
        - Purpose: Core business metric + aggregation
         */

        /*
         GetSalesTrend
        - Input: interval (daily, weekly, monthly), date range
        - Output DTO: Time-series of sales amount
        - Purpose: Trend visualization + grouping
        */

        /*
         GetSalesByRegion
        - Input: country, date range
        - Output DTO: Sales grouped by country or region
        - Purpose: Geographic insight + joins with dim_customers
         */

        /*
         GetOrderDetails
        - Input: order_number
        - Output DTO: Full order breakdown (product, customer, dates, price, quantity)
        - Purpose: Deep join across all three tables
         */

    }
}


// Question:
// if one interface only has one job / one implementation, could i not bypass the interface entirely and directly reference an instance of the class itself?

// ans: Abstraction interfaces (like my gamedev IInteractable) vs other types of interfaces (e.g. contract/capability) e.g. MS's IDisposable interface. Interface handle it idc about implementation

/*
 ans2: makes testing easier.

e.g. with interface, only need to mock the interface, to test the method, dont have to mock all the dependencies of
ExpensesService

keeps it a compact unit test =]
otherwise would have to mock expensesServiec, then because it relies on expensesRepository, you'd have to mock that too, etc etc

interface keep it lean & cleeeean


    public class ExpensesControllerTests
    {
        private readonly IExpensesService _expensesService;
        private readonly ExpensesController _expensesController;

        public ExpensesControllerTests()
        {
            // Inject dependencies for tests (by Mocking)
            _expensesService = A.Fake<IExpensesService>();

            // SUT: System Under Test
            _expensesController = new ExpensesController(_expensesService);
        }

 */

