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
    public class LibreriaLibroConfiguration : IEntityTypeConfiguration<LibreriaLibro>
    {
        public void Configure(EntityTypeBuilder<LibreriaLibro> builder)
        {
            builder.ToTable("LibreriasLibros");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.HasOne(x => x.Libreria).WithMany(x => x.Libros).HasForeignKey(x => x.IdLibreria);
            builder.HasOne(x => x.Libro).WithMany(x => x.Librerias).HasForeignKey(x => x.IdBook);
        }
    }
}
