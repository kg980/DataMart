using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CompanySalesAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace CompanySalesAPI.Models
{
    [Keyless] // Moved to context Model Builder
    [Table("dim_products", Schema = "gold")]
    public class Product
    {
        public int ProductKey { get; set; }
        public int ProductId { get; set; }
        public int ProductNumber { get; set; }
        //[Required]
        public string ProductName { get; set; } = string.Empty;
        public ProductCategoryId CategoryId { get; set; }
        public ProductCategory Category { get; set; }
        //[Required]
        public string Subcategory { get; set; } = string.Empty; // Enum mapping not scalable; large number of values, have spaces. Long-term: Create SQL lookup table. Short term: String.
        public bool Maintenance { get; set; } // 'Bool' -> Yes/No in database rather than True/False. Using Converter in DbContext.
        public int Cost { get; set; }
        //[Required]
        public string ProductLine { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}


/*
[DataMart_DataWarehouse].[gold].[dim_products]
[product_key] -- int
[product_id] -- int
[product_number] -- unique string
[product_name] -- string
[category_id] -- enum (string) (one category can umbrella over multiple category_id's. Corresponds to subcategory)
[category] -- enum (string)
[subcategory] -- enum (string) (one category can umbrella over multiple subcategories's)
[maintenance] -- 'Bool' -> Yes/No rather than True/False
[cost] -- int
[product_line] -- enum (string)
[start_date] -- datetime yyyy-mm-dd

 */

/* Question: is it common practise to give default values in Models?

 e.g.
    public int ProductKey { get; set; } = 0;
    public string ProductName { get; set; } = string.Empty;

or to leave it blank:
        public int ProductKey { get; set; }
        public string ProductName { get; set; }


*/