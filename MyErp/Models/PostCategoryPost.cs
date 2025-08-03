namespace MyErp.Models
{
    public class PostCategoryPost
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public PostCategory PostCategory { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
