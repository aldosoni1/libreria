using PJENL.Shared.Kernel.Data.EntityFrameworkRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Repositories
{
    public interface ILibroRepository : IRepository<Libro,Guid>
    {
        Task<Guid> RelacionarLibroLibreria(Guid idLibro, int idLibreria);
    }
}
