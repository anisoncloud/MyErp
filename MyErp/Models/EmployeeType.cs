namespace MyErp.Models
{
    public class EmployeeType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<LeaveEntitlement>? Entitlements { get; set; }
    }
}
