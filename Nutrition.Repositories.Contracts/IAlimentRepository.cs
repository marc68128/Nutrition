using System;
using System.Collections.Generic;
using Nutrition.Domain;
using Nutrition.Enums;

namespace Nutrition.Repositories.Contracts
{
    public interface IAlimentRepository
    {
        List<Aliment> GetAll();
        List<Aliment> GetByCategory(EnumAlimentCategory category); 
    }
}
