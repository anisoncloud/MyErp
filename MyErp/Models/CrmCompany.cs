using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyErp.Models
{
    public class CrmCompany : BaseEntity
    {
        public int ID  { get; set; }
        [DisplayName("Full Name of Company")]
        public string Name { get; set; }
        [DisplayName("Details about company")]
        public string? Description { get; set; }        
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [DisplayName("Company Email")]
        public string? CompanyEmail { get; set; }
        [DisplayName("Company's Phone Number")]
        public string? CompanyPhone { get; set; }
        [DisplayName("Company's Address/Location")]
        public string? CompanyAddress {  get; set; }
      
        public ICollection<Domain>? Domains { get; set; }
        public ICollection<CrmContact>? CrmContacts { get; set; }
        public ICollection<Hosting>? Hostings { get; set; }
    }
}
