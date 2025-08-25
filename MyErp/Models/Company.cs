using System.ComponentModel.DataAnnotations;

namespace MyErp.Models
{
    public class Company
    {
        public int ID { get; set; }
        [Display(Name = "Company Name")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Users> User { get; set; }
    }
}
