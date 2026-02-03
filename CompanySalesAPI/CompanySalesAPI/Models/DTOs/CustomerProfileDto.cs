using CompanySalesAPI.Models.Enums;

namespace CompanySalesAPI.Models.DTOs
{
    public class CustomerProfileDto
    {
        public long CustomerId { get; set; }
        public string CustomerNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; }
        public string Country { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }

    }
}


/* Customer Model for reference:
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
 */