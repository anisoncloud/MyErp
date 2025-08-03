namespace MyErp.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string? Body { get; set; }
        public ICollection<PostCategoryPost> PostCategoryPosts { get; set; }
    }
}
