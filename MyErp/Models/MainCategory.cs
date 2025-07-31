namespace MyErp.Models
{
    public class MainCategory
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public ICollection<ProductMainCategory> ProductMainCategories { get; set; }
    }
}
