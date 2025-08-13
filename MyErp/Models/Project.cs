namespace MyErp.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateOnly? DemoStartDate {get; set;}
        public DateOnly? WorkOrderDate {get; set;}
        public int? ProjectDays { get; set;}
        public DateOnly? ProjectDeliveryDate {get; set;}
        public decimal? ProjectValue { get; set;} 
        public decimal? Advanced { get; set;} 
        public string? ProjectDetails {  get; set; }
        public string? Comments {  get; set; }
        public ICollection<PeopleProject> PeopleProjects { get; set; }
    }
}
