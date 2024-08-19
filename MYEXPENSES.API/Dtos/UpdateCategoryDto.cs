using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Dtos
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Title must be 150 characters or less")]
        public string Title { get; set; }
    }
}
