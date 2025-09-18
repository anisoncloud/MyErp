using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyErp.Models
{
    public class Domain : BaseEntity
    {
        public int Id { get; set; }
        public string DomainName { get; set; }
        public string? IpAddress { get; set; }
        public string? Hosting {  get; set; }
        public string? DomainRegistrant  { get; set; }
        public DateTime? RegistarDate { get; set; }
        public int? ForYear {  get; set; }        
        public DateTime? ExpireDate { get; set; }
        public string? Dns {  get; set; }
        public string? Analytics { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public CrmCompany? CrmCompany { get; set; }
        public string? Comments { get; set; }
    }
}
