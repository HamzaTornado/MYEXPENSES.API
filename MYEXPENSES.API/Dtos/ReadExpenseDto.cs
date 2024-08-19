using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Dtos
{
    public class ReadExpenseDto
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public int Month { get; set; }

        public int SubCategoryId { get; set; }

        public ReadSubCategoryDto SubCategory { get; set; }
    }
}
