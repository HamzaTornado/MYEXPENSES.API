using AutoMapper;
using MYEXPENSES.API.Dtos;
using MYEXPENSES.API.Models;

namespace MYEXPENSES.API.Profiles
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategory, ReadSubCategoryDto>();
            CreateMap<ReadSubCategoryDto, SubCategory>();

            CreateMap<CreateSubCategoryDto, SubCategory>();
            CreateMap<SubCategory, CreateSubCategoryDto>();

            CreateMap<SubCategory, UpdateSubCategoryDto>();
            CreateMap<UpdateSubCategoryDto, SubCategory>();
        }
    }
}
