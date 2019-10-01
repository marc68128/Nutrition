using Nutrition.Core.Enums;

namespace Nutrition.Wpf.ViewModels.Contracts
{
    public interface IAlimentViewModel
    {
        int Quantity { get; set; }
        string Name { get; set; }
        double Calories { get; set; }
        double Protides { get; set; }
        double Lipides { get; set; }
        double Glucides { get; set; }
        EnumAlimentCategory Category { get; set; }
        string SubCategory { get; set; }
        EnumUnit Unit { get; set; }
    }
}
