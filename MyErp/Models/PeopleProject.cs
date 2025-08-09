namespace MyErp.Models
{
    public class PeopleProject
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
