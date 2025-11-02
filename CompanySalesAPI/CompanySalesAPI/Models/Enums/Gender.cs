using System.Runtime.Serialization;

namespace CompanySalesAPI.Models.Enums
{
    public enum Gender
    {
        [EnumMember(Value = "Male")]
        Male,

        [EnumMember(Value = "Female")]
        Female,

        [EnumMember(Value = "N/A")]
        NotApplicable
    }
}
