using Assignment.Models.DataModels;
using Assignment.Models.ViewModels;
using AutoMapper;

namespace Assignment.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductDataModel,ProductViewModel>().ReverseMap();
            CreateMap<AuditLog, AuditViewModel>().ReverseMap();
        }
    }
}
