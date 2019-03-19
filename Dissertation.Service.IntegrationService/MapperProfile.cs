using AutoMapper;
using Dissertation.Data.Context;

namespace Dissertation.Service.IntegrationService
{
    public class MappingProfile 
    {
        public static void InitializeAutoMapper()
        {
            //Mapper.CreateMap<V_SENSIS_CL2, Measurment>();
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<V_SENSIS_CL2, Measurment>()
                        .ForMember(cl2 => cl2.Value, opt => opt.MapFrom(src => src.P0037))
                        .ForMember(cl2 => cl2.SensisID, opt => opt.MapFrom(src => src.MSid));
                });
        }
    }
}
