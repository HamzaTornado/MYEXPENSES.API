using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Models
{
    public class MonthBalance
    {
        [Key]
        public int Id { get; set; }
        public int MonthNumber { get; set; }
        public double TotalIncome { get; set; }
        public double TotalExpenses { get; set; }
        public double Balance => TotalIncome - TotalExpenses;
        
    }
}
