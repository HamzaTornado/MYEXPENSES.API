using AutoMapper;
using MYEXPENSES.API.Dtos;
using MYEXPENSES.API.Models;

namespace MYEXPENSES.API.Profiles
{
    public class IncomProfile : Profile
    {
        public IncomProfile()
        {
            CreateMap<Income, CreateIncomeDto>();
            CreateMap<CreateIncomeDto, Income>();

            CreateMap<Income, ReadIncomeDto>();
            CreateMap<ReadIncomeDto, Income>();

            CreateMap<Income, UpdateIncomeDto>();
            CreateMap<UpdateIncomeDto, Income>();
        }
    }
}
