using Nutrition.Dtos;

namespace Nutrition.Api.ViewModels.Configuration
{
    public class ViewModelsMappingProfile : AutoMapper.Profile
    {
        public ViewModelsMappingProfile()
        {
            CreateTwoWayMap<AlimentDto, AlimentViewModel>();
            CreateTwoWayMap<MealDto, MealViewModel>();
            CreateTwoWayMap<MealPartDto, MealPartViewModel>();
        }

        private void CreateTwoWayMap<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}
