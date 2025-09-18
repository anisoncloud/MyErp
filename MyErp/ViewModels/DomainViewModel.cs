using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyErp.ViewModels
{
    public class DomainViewModel
    {
        public int DomainId { get; set; }
        [DisplayName("Domain Name")]
        public string DomainName { get; set; }
        public string CompanyName { get; set; }
        [DisplayName("IP Address")]
        public string IpAddress { get; set; }
        public string Hosting { get; set; }
        public string DomainRegistrant { get; set; }
        [DisplayName("Register Date")]        
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime RegistarDate { get; set; }
        public int ForYear { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpireDate { get; set; }
        public string Dns { get; set; }
        public string Analytics { get; set; }
        public string Comments { get; set; }
        public int CompanyId {  get; set; }
        public List<SelectListItem> CrmCompanies { get; set; }
    }
}
