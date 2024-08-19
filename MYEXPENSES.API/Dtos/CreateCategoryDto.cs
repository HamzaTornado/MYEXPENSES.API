using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Dtos
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(150,ErrorMessage = "Title must be 150 characters or less")]
        public string Title { get; set; }

    }
}
