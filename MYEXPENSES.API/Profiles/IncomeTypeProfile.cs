using AutoMapper;
using MYEXPENSES.API.Dtos;
using MYEXPENSES.API.Models;

namespace MYEXPENSES.API.Profiles
{
    public class IncomeTypeTypeProfile : Profile
    {
        public IncomeTypeTypeProfile() {

            CreateMap<IncomeType, CreateIncomeTypeDto>();
            CreateMap<CreateIncomeTypeDto, IncomeType>();

            CreateMap<IncomeType, ReadIncomeTypeDto>();
            CreateMap<ReadIncomeTypeDto, IncomeType>();

            CreateMap<IncomeType, UpdateIncomeTypeDto>();
            CreateMap<UpdateIncomeTypeDto, IncomeType>();
        }

    }
}
