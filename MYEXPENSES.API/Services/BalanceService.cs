using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MYEXPENSES.API.Dtos;
using MYEXPENSES.API.Models;

namespace MYEXPENSES.API.Services
{
    public class BalanceService
    {
        private readonly MyExpensesContext _context;
        private readonly IMapper _mapper;

        public BalanceService(MyExpensesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        public async Task<ReadMonthBalanceDto> GetBalanceByMonth(int month)
        {
            var expenses = await _context.Expenses.Where(e => e.Month == month).ToListAsync();
            var incomes = await _context.Incomes.Where(i => i.Month == month).ToListAsync();

            double totalexpenses = 0;
            double totalincomes = 0;
            double monthbalance = 0;
            foreach (var expense in expenses)
            {
                totalexpenses += expense.Amount;
            }
            foreach (var income in incomes)
            {
                totalincomes += income.Amount;
            }
            monthbalance = totalincomes - totalexpenses;

            var readdto = new ReadMonthBalanceDto()
            {
                MonthNumber = month,
                TotalExpenses = totalexpenses,
                TotalIncome = totalincomes,
            };

            return readdto;
        }
    }
}
