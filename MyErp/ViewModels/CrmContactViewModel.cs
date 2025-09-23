using Microsoft.AspNetCore.Mvc.Rendering;
using MyErp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyErp.ViewModels
{
    public class CrmContactViewModel
    {
        public string Name { get; set; }
        public string? Designation { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Photo { get; set; }
        public string? Comments { get; set; }
        public int CrmCompanyId { get; set; }
        public List<SelectListItem> CrmCompany { get; set; }
    }
}
