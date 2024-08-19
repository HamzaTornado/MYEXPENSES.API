using AutoMapper;
using MYEXPENSES.API.Dtos;
using MYEXPENSES.API.Models;

namespace MYEXPENSES.API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<CreateCategoryDto,Category>();

            CreateMap<Category, ReadCategoryDto>();
            CreateMap<ReadCategoryDto, Category>();

            CreateMap<Category, UpdateCategoryDto>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
