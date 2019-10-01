namespace Nutrition.Api.ViewModels
{
    public class MealPartViewModel
    {
        private AlimentViewModel _aliment;
        private double _quantity;

        public AlimentViewModel Aliment
        {
            get => _aliment;
            set
            {
                _aliment = value;
                UpdateTotal();
            }
        }
        public double Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                UpdateTotal();
            }
        }

        public double TotalQuantity { get; private set; }
        public double TotalCalories { get; private set; }
        public double TotalProtides { get; private set; }
        public double TotalLipides { get; private set; }
        public double TotalGlucides { get; private set; }

        private void UpdateTotal()
        {
            TotalQuantity = Quantity * Aliment.Quantity;
            TotalCalories = Quantity * Aliment.Calories;
            TotalProtides = Quantity * Aliment.Protides;
            TotalLipides = Quantity * Aliment.Lipides;
            TotalGlucides = Quantity * Aliment.Glucides;
        }
    }
}
