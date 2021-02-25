using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSA.DesafioCrud.Domain.Models;
using TDSA.DesafioCrud.Infra.Data.EntityConfig;

namespace TDSA.DesafioCrud.Infra.Data.Context
{
    public class DesafioCrudContext : DbContext
    {
        public DesafioCrudContext()
            //: base("DesafioCrudContext")
        {
            Database.SetInitializer<DesafioCrudContext>(null);

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
               .Configure(p => p.HasColumnType("VARCHAR"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfig());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
