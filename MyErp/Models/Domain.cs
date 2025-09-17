using System.ComponentModel.DataAnnotations.Schema;

namespace MyErp.Models
{
    public class Domain : BaseEntity
    {
        public int Id { get; set; }
        public string DomainName { get; set; }
        public string IpAddress { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public CrmCompany CrmCompany { get; set; }
    }
}
