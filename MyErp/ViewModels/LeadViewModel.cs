using Microsoft.AspNetCore.Mvc.Rendering;
using MyErp.Models;

namespace MyErp.ViewModels
{
    public class LeadViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Comment { get; set; }
        public int CrmCompanyId {  get; set; }
        public List<SelectListItem> CrmCompanies { get; set; }
    }
}
