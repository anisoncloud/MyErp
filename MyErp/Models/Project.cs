using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ProjectValue { get; set;}
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Advanced { get; set;} 
        public string? ProjectDetails {  get; set; }
        public string? Comments {  get; set; }
        public ICollection<PeopleProject> PeopleProjects { get; set; }
        public decimal? DuePayment
        {
            get
            {
                return ProjectValue - Advanced;
            }
        }
    }
}
