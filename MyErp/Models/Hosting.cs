using System.ComponentModel.DataAnnotations.Schema;

namespace MyErp.Models
{
    public class Hosting
    {
        public int Id { get; set; }
        public int DomainId {  get; set; }
        public Domain Domain { get; set; }
        public int CrmCompanyId { get; set; }
        public CrmCompany CrmCompany { get; set; }
        public DateTime HostingStartDate {  get; set; }
        public DateTime HostingExpireDate {  get; set; }
        public DateTime HostingUpdatedDate {  get; set; }
        public int HostingDuration {  get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePerYear {  get; set; }
        public int Package {  get; set; }
        public string? Comment { get; set; }
    }
}
