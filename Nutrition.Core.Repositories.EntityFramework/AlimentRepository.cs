using Nutrition.Core.Domain;
using Nutrition.Core.Enums;
using Nutrition.Core.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using Nutrition.Core.Repositories.EntityFramework.Data;

namespace Nutrition.Core.Repositories.EntityFramework
{
    internal class AlimentRepository : IAlimentRepository
    {
        private readonly NutContext _context;

        public AlimentRepository(NutContext context)
        {
            _context = context;
        }
        public List<Aliment> GetAll()
        {
            return _context.Aliments.ToList();
        }

        public List<Aliment> GetByCategory(EnumAlimentCategory category)
        {
            return GetAll().Where(a => a.Category == category).ToList();
        }
    }
}
