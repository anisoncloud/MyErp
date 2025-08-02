using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyErp.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<int> SelectedMainCategoryIds { get; set; }
        public List<SelectListItem> AllMainCategories { get; set; }
    }
}
