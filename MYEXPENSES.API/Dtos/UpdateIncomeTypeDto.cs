using MYEXPENSES.API.Models;
using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Dtos
{
    public class UpdateIncomeTypeDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

    }
}
