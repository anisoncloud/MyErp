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
        [DisplayName("Contact Person Full Name")]
        public string? ContactPerson {  get; set; }
        [DisplayName("Designation")]
        public string? Designation {  get; set; }
        [DisplayName("Contact Person's Mobile")]
        public string? ContactPersonPhone {  get; set; }
        [DisplayName("Contact Person's Email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? ContactPersonEmail {  get; set; }
        public ICollection<Domain>? Domains { get; set; }
        public ICollection<CrmContact>? CrmContacts { get; set; }
    }
}
