using Nutrition.Dtos;
using Nutrition.Enums;
using System.Collections.Generic;

namespace Nutrition.Services.Contracts
{
    public interface IAlimentService
    {
        List<AlimentDto> GetAll();
        List<AlimentDto> GetByCategory(EnumAlimentCategory category);
    }
}
