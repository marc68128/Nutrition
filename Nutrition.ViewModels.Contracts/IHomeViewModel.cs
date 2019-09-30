using System.Collections.Generic;

namespace Nutrition.ViewModels.Contracts
{
    public interface IHomeViewModel : IBaseViewModel
    {
        List<IAlimentViewModel> Aliments { get; set; }
    }
}
