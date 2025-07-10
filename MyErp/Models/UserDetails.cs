namespace MyErp.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string PhoneNumberOne { get; set; }
        public string PhoneNumberTwo { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public Users User { get; set; }
    }
}
