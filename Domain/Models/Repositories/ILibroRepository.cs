using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Repositories
{
    public interface ILibroRepository
    {
        Task<IEnumerable<Libro>> GetLibros(string searchValue = null, int skip = 0, int take = 10);
        Task<Guid> Registrar(Libro libro);
        Task Actualizar(Libro libro);
        Task<bool> Eliminar(Guid id);
        Task<Libro> GetById(Guid id);
        Task<IEnumerable<Guid>> RegistrarN(IEnumerable<Libro> libros);
        Task<Guid> RelacionarLibroLibreria(Guid idLibro, int idLibreria);
    }
}
