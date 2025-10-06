using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyErp.Models
{
    public class ChartOfAccount : BaseEntity
    {
        [Key]
        public int AccountId {  get; set; }
        public string AccountCode {  get; set; }
        public string AccountName { get; set; }
        public string AccountType {  get; set; }
        public string? Description {  get; set; }
        public string? SubType {  get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal OpeningBalance {  get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; } = true;
        public int? ParentAccountId {  get; set; }
        public ChartOfAccount? ParentAccount { get; set; }
        [ValidateNever]
        public ICollection<JournalLine> Lines { get; set; }
    }
}
