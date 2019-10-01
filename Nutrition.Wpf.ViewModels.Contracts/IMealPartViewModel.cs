namespace Nutrition.Wpf.ViewModels.Contracts
{
    public interface IMealPartViewModel : IBaseViewModel
    {
        IAlimentViewModel Aliment { get; set; }
        double Quantity { get; set; }
        double TotalQuantity { get; }
    }
}
