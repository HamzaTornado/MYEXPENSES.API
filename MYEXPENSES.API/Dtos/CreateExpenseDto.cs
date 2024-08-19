using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Dtos
{
    public class CreateExpenseDto
    {
        public string? Description { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, 12)]
        public int Month { get; set; }

        [Required]
        public int SubCategoryId { get; set; }
    }
}
