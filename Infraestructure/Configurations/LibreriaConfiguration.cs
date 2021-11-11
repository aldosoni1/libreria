using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Configurations
{
    public class LibreriaConfiguration : IEntityTypeConfiguration<Libreria>
    {
        public void Configure(EntityTypeBuilder<Libreria> builder)
        {
            builder.ToTable("Librerias");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdLibreria").HasComment("Llave de la tabla libreria").ValueGeneratedOnAdd();
            builder.Property(x => x.Nombre).HasMaxLength(50).IsRequired();
            builder.HasMany(libreria => libreria.Libros)
                .WithOne(libroLibreria => libroLibreria.Libreria)
                .HasForeignKey(libroLibreria => libroLibreria.IdLibreria);
        }
    }
}
