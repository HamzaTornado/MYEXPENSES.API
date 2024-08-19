using MYEXPENSES.API.Models;
using System.ComponentModel.DataAnnotations;

namespace MYEXPENSES.API.Dtos
{
    public class ReadIncomeDto
    {
        public int Id { get; set; }

        public double Amount { get; set; }
        
        public DateTime Date { get; set; }

        public int Month { get; set; }

        public int IncomeTypeId { get; set; }

        public ReadIncomeTypeDto IncomeType { get; set; }
    }
}
