using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
