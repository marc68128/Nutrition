using Nutrition.Dtos;
using Nutrition.ViewModels.Contracts;

namespace Nutrition.ViewModels.Configuration
{
    public class ViewModelsMappingProfile : AutoMapper.Profile
    {
        public ViewModelsMappingProfile()
        {
            //CreateTwoWayMap<AlimentDto, AlimentViewModel>();
            CreateTwoWayMap<AlimentDto, IAlimentViewModel>();
        }

        private void CreateTwoWayMap<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}
