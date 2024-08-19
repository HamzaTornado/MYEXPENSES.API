using MYEXPENSES.API.Models;
using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Dtos
{
    public class ReadAllCategories
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<ReadSubCategoryDto> ReadSubCategories { get; set; }
    }
}
