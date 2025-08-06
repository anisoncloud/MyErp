using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyErp.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string PostName { get; set; }
        public string Body { get; set; }
        public List<int> SelectPostCategoryIds { get; set; }
        public List<SelectListItem> AllPostCategories { get; set; }
    }
}
