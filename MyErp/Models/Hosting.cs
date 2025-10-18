namespace MyErp.Models
{
    public class Hosting : BaseEntity
    {
        public int Id { get; set; }
        public string DomainId {  get; set; }
        public Domain Domain { get; set; }
        public int CrmCompanyId { get; set; }
        public CrmCompany CrmCompany { get; set; }
        public DateTime HostingStartDate {  get; set; }
        public DateTime HostingExpireDate {  get; set; }
        public DateTime HostingUpdatedDate {  get; set; }
        public int HostingDuration {  get; set; }
        public decimal PricePerYear {  get; set; }
        public int Package {  get; set; }
        public string? Comment { get; set; }
    }
}
