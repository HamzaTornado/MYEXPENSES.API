using MYEXPENSES.API.Models;
using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Dtos
{
    public class CreateIncomeDto
    {


        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, 12)]
        public int Month { get; set; }

        [Required]
        public int IncomeTypeId { get; set; }

    }
}
