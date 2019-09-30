using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrition.ViewModels.Contracts
{
    public interface IMealPartViewModel : IBaseViewModel
    {
        IAlimentViewModel Aliment { get; set; }
        double Quantity { get; set; }
    }
}
