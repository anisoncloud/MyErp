using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyErp.Models
{
    public class CrmCompany : BaseEntity
    {
        public int ID  { get; set; }        
        public string Name { get; set; }        
        public string? Description { get; set; }        
        public string? CompanyEmail { get; set; }        
        public string? CompanyPhone { get; set; }        
        public string? CompanyAddress {  get; set; }      
        public ICollection<Domain>? Domains { get; set; }
        public ICollection<CrmContact>? CrmContacts { get; set; }
        public ICollection<Hosting>? Hostings { get; set; }
    }
}
