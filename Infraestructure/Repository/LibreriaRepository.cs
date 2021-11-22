using Domain.Models;
using Domain.Models.Repositories;
using PJENL.Shared.Kernel.Data.EntityFrameworkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class LibreriaRepository : Repository<Libreria, int>, ILibreriaRepository
    {
        private readonly Contexto _contexto;
        public LibreriaRepository(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
