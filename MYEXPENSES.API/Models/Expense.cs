using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

    }
}
