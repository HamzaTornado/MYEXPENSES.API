using MYEXPENSES.API.Models;

namespace MYEXPENSES.API.Dtos
{
    public class ReadCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //public ICollection<SubCategory> SubCategories { get; set; }
    }
}
