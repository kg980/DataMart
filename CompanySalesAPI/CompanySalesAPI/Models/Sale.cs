using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CompanySalesAPI.Models
{
    //[Keyless] moved to model context builder
    [Table("fact_sales", Schema = "gold")]
    public class Sale
    {
        //public int Id { get; set; }
        [Required]
        public string OrderNumber { get; set; } = string.Empty;     // Unique string
        public int ProductKey { get; set; }
        
        public int CustomerId { get; set; }



        // Alternative to manually making CustomerSalesAggregate
        //[Required]    // loads the entire customer, e.g. for the use case of reading customer dets when getting customer by most sales.
        public required Customer Customer { get; set; } // navigational property. Customer <one  many> Sales
        // when do entity framework migration, creates linking table so I dont need to make CustomerSalesAggregate myself


        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime DueDate { get; set; }
        public int SalesAmount { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }



    }
}


/*
[DataMart_DataWarehouse].[gold].[fact_sales]

[order_number] -- unique string
[product_key] -- int. Improvement: replace with GUID (Out of scope for this project, I am not altering the data)
[customer_id] -- int
[order_date] -- datetime yyyy-mm-dd
[shipping_date] -- datetime yyyy-mm-dd
[due_date] -- datetime yyyy-mm-dd
[sales_amount] -- int (total quantity * price)
[quantity] -- quantity
[price] -- int
 */