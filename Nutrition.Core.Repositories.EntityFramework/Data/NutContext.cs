using System.Data.Entity;
using Nutrition.Core.Domain;

namespace Nutrition.Core.Repositories.EntityFramework.Data
{
    public class NutContext : DbContext
    {
        public NutContext(string connectionString) : base(connectionString)
        { }

        public DbSet<Aliment> Aliments { get; set; }
    }
}
