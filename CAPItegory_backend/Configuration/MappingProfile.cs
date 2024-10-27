using AutoMapper;
using CAPItegory_backend.Models;
using CAPItegory_backend.Rows;

namespace CAPItegory_backend.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryRow>()
                .ForMember(dest => dest.IsRoot, opt => opt.MapFrom(src => src.Parent == null));
        }
    }
}
