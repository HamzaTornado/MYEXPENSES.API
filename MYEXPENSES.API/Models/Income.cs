using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Models
{
    public class Income
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Month {  get; set; }

        [Required]
        public int IncomeTypeId { get; set; }

        public IncomeType IncomeType { get; set; }

    }
}
