namespace MyErp.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<PeopleProject> PeopleProjects { get; set; }
    }
}
