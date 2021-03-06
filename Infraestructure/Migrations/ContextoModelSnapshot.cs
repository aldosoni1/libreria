// <auto-generated />
using System;
using Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructure.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Libreria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdLibreria")
                        .HasComment("Llave de la tabla libreria")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Librerias");
                });

            modelBuilder.Entity("Domain.Models.LibreriaLibro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<Guid>("IdBook")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdLibreria")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBook");

                    b.HasIndex("IdLibreria");

                    b.ToTable("LibreriasLibros");
                });

            modelBuilder.Entity("Domain.Models.Libro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("Autor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaEliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroPaginas")
                        .HasColumnType("int");

                    b.Property<Guid?>("UsuarioElimino")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioModifico")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioRegistro")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("Domain.Models.LibreriaLibro", b =>
                {
                    b.HasOne("Domain.Models.Libro", "Libro")
                        .WithMany("Librerias")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Libreria", "Libreria")
                        .WithMany("Libros")
                        .HasForeignKey("IdLibreria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Libreria");

                    b.Navigation("Libro");
                });

            modelBuilder.Entity("Domain.Models.Libreria", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("Domain.Models.Libro", b =>
                {
                    b.Navigation("Librerias");
                });
#pragma warning restore 612, 618
        }
    }
}
