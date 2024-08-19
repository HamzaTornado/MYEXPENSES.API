namespace MYEXPENSES.API.Dtos
{
    public class ReadMonthBalanceDto
    {
        public int MonthNumber { get; set; }
        public double TotalIncome { get; set; }
        public double TotalExpenses { get; set; }
        public double Balance => TotalIncome - TotalExpenses;
    }
}
