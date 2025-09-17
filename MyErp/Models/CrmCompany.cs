namespace MyErp.Models
{
    public class CrmCompany
    {
        public int ID  { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CompanyEmail { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyAddress {  get; set; }
        public ICollection<Domain>? Domains { get; set; }
    }
}
