using System;
using CompanySalesAPI.Models.Enums;

namespace CompanySalesAPI.Models
{
    public class Customer
    {
        public int CustomerKey { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public string CustomerNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public MaritalStatus MaritalStatus { get; set; } // Enum property

        public Gender Gender { get; set; } // Enum property
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}


/*
[DataMart_DataWarehouse].[gold].[dim_customers]

[customer_key] -- int
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