using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MyErp.ViewModels
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? DemoStartDate { get; set; }
        public DateOnly? WorkOrderDate { get; set; }
        public int? ProjectDays { get; set; }
        public DateOnly? ProjectDeliveryDate { get; set; }
        public decimal? ProjectValue { get; set; }
        public decimal? Advanced { get; set; }
        public string? ProjectDetails { get; set; }
        public string? Comments { get; set; }
        public List<int> SelectedPeopleIds {  get; set; }
        public List<SelectListItem> AllPeoples { get; set; }        
    }
}
