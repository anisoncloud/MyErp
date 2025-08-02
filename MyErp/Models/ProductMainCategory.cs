namespace MyErp.Models
{
    public class ProductMainCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
    }
}
