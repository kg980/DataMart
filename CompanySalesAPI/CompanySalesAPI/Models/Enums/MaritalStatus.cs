using System.Runtime.Serialization;

namespace CompanySalesAPI.Models.Enums
{
    public enum MaritalStatus
    {
        [EnumMember(Value = "Single")]
        Single,

        [EnumMember(Value = "Married")]
        Married,

        [EnumMember(Value = "N/A")]
        NotApplicable
    }
}
