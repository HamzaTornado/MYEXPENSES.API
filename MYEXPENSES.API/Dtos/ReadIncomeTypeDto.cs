using MYEXPENSES.API.Models;
using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Dtos
{
    public class ReadIncomeTypeDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        //public ICollection<ReadIncomeDto> Incomes { get; set; }
    }
}
