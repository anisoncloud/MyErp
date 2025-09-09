using System.Runtime.Serialization;

namespace MyErp.Models
{
    public enum Gender
    {
        [EnumMember(Value ="MALE")]
        Male,
        [EnumMember(Value ="FEMALE")]
        Female
    }
}
