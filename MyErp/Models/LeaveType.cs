namespace MyErp.Models
{
    public class LeaveType
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsEarned {  get; set; }
        public int CarryForwardLimit { get; set; } = 5;
        public ICollection<LeaveEntitlement>? Entitlements { get; set; }
    }
}
