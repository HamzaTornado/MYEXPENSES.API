using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Dtos
{
    public class CreateSubCategoryDto
    {
        [Required]
        [MaxLength(150, ErrorMessage = "Title must be 150 characters or less")]
        public string Title { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
