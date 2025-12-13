namespace MyErp.Models
{
    public class EmployeeSalary
    {
        public int Id { get; set; }
        public string? UserId {  get; set; }
        public int? BasicSalary {  get; set; }
        public int? HouseRent {  get; set; }
        public int? MedicalAllowance { get; set; }
        public int? DearnessAllowance {  get; set; }
        public int? MobileAllowance {  get; set; }
        public int? FoodSubsidy { get; set; }
        public Users? Users { get; set; }
    }
}
