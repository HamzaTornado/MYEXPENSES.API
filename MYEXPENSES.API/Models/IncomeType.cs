using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Models
{
    public class IncomeType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Income> Incomes { get; set; }

    }
}
