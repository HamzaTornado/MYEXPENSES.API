using MYEXPENSES.API.Models;
using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Dtos
{
    public class CreateIncomeTypeDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;


    }
}
