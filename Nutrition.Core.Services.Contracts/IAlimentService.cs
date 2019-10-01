using Nutrition.Core.Dtos;
using Nutrition.Core.Enums;
using System.Collections.Generic;

namespace Nutrition.Core.Services.Contracts
{
    public interface IAlimentService
    {
        List<AlimentDto> GetAll();
        List<AlimentDto> GetByCategory(EnumAlimentCategory category);
    }
}
