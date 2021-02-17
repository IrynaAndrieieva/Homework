using Pharmacy.Data.Models;
using System.Data.Entity;

namespace Pharmacy.Data
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext() : base("Data Source =.; Initial Catalog = PharmacyMigration; Integrated Security = True") { }
        public PharmacyContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Form> Forms { get; set; }
    }
}
