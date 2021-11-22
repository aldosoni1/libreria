using Application.ViewModel;
using Domain.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using PJENL.Shared.Kernel.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LibreriaService : ILibreriaService
    {
        private readonly ILibreriaRepository _libreriaRepository;
        public LibreriaService(ILibreriaRepository libreriaRepository)
        {
            _libreriaRepository = libreriaRepository;
        }
        public async Task<IEnumerable<ICatalogoInt>> GetAll(string searchValue = null, int skip = 0, int take = 10)
        {
            var librerias = _libreriaRepository.GetAllQueryableRepository();
            if (!string.IsNullOrWhiteSpace(searchValue))
                librerias = librerias.Where(x => x.Nombre.Contains(searchValue));
            var data = await librerias.ToListAsync();
            return data.Select(x => new LibreriaViewModel { Descripcion = x.Nombre, Id = x.Id });
        }
    }
}
