using MYEXPENSES.API.Models;
using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Dtos
{
    public class UpdateIncomeDto
    {
        public int Id { get; set; }

        [Required]

        public double Amount { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public int IncomeTypeId { get; set; }
    }
}
