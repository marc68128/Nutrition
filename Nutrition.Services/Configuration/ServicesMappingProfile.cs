using Nutrition.Domain;
using Nutrition.Dtos;

namespace Nutrition.Services.Configuration
{
    public class ServicesMappingProfile : AutoMapper.Profile
    {
        public ServicesMappingProfile()
        {
            CreateTwoWayMap<Aliment, AlimentDto>();
        }

        private void CreateTwoWayMap<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}
