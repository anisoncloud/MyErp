using System.ComponentModel.DataAnnotations;

namespace MyErp.Models
{
    public class Department: BaseEntity
    {
        public int ID { get; set; }
        [Display(Name = "Department")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
