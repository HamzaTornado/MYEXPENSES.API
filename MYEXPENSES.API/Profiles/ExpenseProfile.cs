using AutoMapper;
using MYEXPENSES.API.Dtos;
using MYEXPENSES.API.Models;

namespace MYEXPENSES.API.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, CreateExpenseDto>();
            CreateMap<CreateExpenseDto,Expense>();

            CreateMap<Expense, ReadExpenseDto>();
            CreateMap<ReadExpenseDto, Expense>();

            CreateMap<Expense, UpdateExpenseDto>();
            CreateMap<UpdateExpenseDto, Expense>();
        }
    }
}
