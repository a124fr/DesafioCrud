using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSA.DesafioCrud.Domain.Models;

namespace TDSA.DesafioCrud.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.Id);
            
            Property(c => c.Id)                
                .HasColumnName("CLI_ID");

            Property(c => c.Nome)
                .HasColumnName("CLI_NOME")
                .HasMaxLength(120)
                .IsRequired();

            Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnType("DATE")
                .HasColumnName("CLI_DATANASCIMENTO");

            Property(c => c.Ativo)
                .IsRequired()
                .HasColumnType("BIT")
                .HasColumnName("CLI_ATIVO");

            ToTable("CLIENTE");
        }
    }
}
