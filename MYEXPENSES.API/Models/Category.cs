using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public ICollection<SubCategory> SubCategories { get; set;}

    }
}
