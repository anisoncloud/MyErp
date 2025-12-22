namespace MyErp.Models
{
    public class PublicHolidays
    {
        public int Id { get; set; }
        public string HolidayName {  get; set; }
        public DateTime HolidayDate {  get; set; }
        public string? Description { get; set; }
        public bool IsPublicHoliday { get; set; }
    }
}
