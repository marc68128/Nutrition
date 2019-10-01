using Nutrition.Wpf.ViewModels.Contracts;

namespace Nutrition.Wpf.ViewModels
{
    internal class MealPartViewModel : BaseViewModel, IMealPartViewModel
    {
        public IAlimentViewModel Aliment { get; set; }
        public double Quantity { get; set; }
        public double TotalQuantity => Quantity * Aliment.Quantity;
    }
}
