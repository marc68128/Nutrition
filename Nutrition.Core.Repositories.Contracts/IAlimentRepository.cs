using Nutrition.Core.Domain;
using Nutrition.Core.Enums;
using System.Collections.Generic;

namespace Nutrition.Core.Repositories.Contracts
{
    public interface IAlimentRepository
    {
        List<Aliment> GetAll();
        List<Aliment> GetByCategory(EnumAlimentCategory category);
    }
}
