using Nutrition.Dtos;
using Nutrition.ViewModels.Contracts;

namespace Nutrition.ViewModels.Configuration
{
    public class ViewModelsMappingProfile : AutoMapper.Profile
    {
        public ViewModelsMappingProfile()
        {
            CreateTwoWayMap<AlimentDto, IAlimentViewModel>();
            CreateTwoWayMap<MealDto, IMealViewModel>();
            CreateTwoWayMap<MealPartDto, IMealPartViewModel>();
        }

        private void CreateTwoWayMap<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}
