namespace MyErp.Models
{
    public class Lead
    {
        public int ID  { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber {  get; set; }
        public string? Email {  get; set; }
        public string? Comment { get; set; }
        public int CrmCompanyId { get; set; }
        public CrmCompany CrmCompanies { get; set; }
    }
}
