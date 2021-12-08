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
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libros");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.HasMany(x => x.Librerias).WithOne(x => x.Libro).HasForeignKey(x=>x.IdBook);
            builder.HasQueryFilter(libro => EF.Property<bool>(libro, nameof(libro.Eliminado)) == false);
        }
    }
}
