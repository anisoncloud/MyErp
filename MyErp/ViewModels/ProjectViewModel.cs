using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyErp.ViewModels
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<int> SelectedPeopleIds {  get; set; }
        public List<SelectListItem> AllPeoples { get; set; }
    }
}
