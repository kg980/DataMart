using System;
using System.ComponentModel.DataAnnotations.Schema;
using CompanySalesAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace CompanySalesAPI.Models
{
    //[Keyless] Moved to context Model Builder
    [Table("dim_customers", Schema = "gold")]
    public class Customer
    {
        public long CustomerKey { get; set; }
        public int CustomerId { get; set; }
        public string CustomerNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public MaritalStatus MaritalStatus { get; set; } // Enum property

        public Gender Gender { get; set; } // Enum property
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }


        public IEnumerable<Sale> Sales { get; set; }
    }
}


/*
[DataMart_DataWarehouse].[gold].[dim_customers]

[customer_key] -- long
[customer_id] -- int
[customer_number] -- unique string
[first_name] -- string
[last_name] -- string
[country] -- string (could be an enum of strings)
[marital_status] -- enum string ('Single' or 'Married')
[gender] -- enum string ('Male' or 'Female' or 'N/A' for undeclared)
[birthdate] -- datetime yyyy-mm-dd
[create_date] -- datetime yyyy-mm-dd
 */



/*
 Confirm data types of table in SQL SSMS:
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'dim_customers' AND TABLE_SCHEMA = 'gold';

 */