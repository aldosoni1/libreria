using Application.InputModel;
using Application.ViewModel;
using Domain.Models;
using Domain.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using PJENL.Shared.Kernel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _repository;
        public LibroService(ILibroRepository libroRepository)
        {
            _repository = libroRepository;
        }
        public async Task<LibroViewModel> Actualizar(LibroEditInputModel editInputModel)
        {
            var data = await _repository.GetRepositoryAsync(editInputModel.Id);
            data.Nombre = editInputModel.Nombre;
            data.NumeroPaginas = editInputModel.NumeroHojas;
            data.Autor = editInputModel.Autor;
            await _repository.Update(data);
            return new LibroViewModel(data.Id, data.Nombre, data.Autor, data.NumeroPaginas);
        }

        public async Task<bool> Eliminar(Guid id)
        {
            return await _repository.RemoveByIdRepositoryAsync(id);
        }

        public async Task<GridResponse<IEnumerable<LibroViewModel>, LibroViewModel>> GetAll(string searchValue = null, int skip = 0, int take = 10)
        {
            var query = _repository.GetAllQueryableRepository();

            if (!string.IsNullOrWhiteSpace(searchValue))
                query = query.Where(x => x.Nombre.Contains(searchValue));
            var data = await query.Skip(skip).Take(take).ToListAsync();
            var totalCount = await _repository.GetAllQueryableRepository().CountAsync();
            return new GridResponse<IEnumerable<LibroViewModel>, LibroViewModel>(data.Select(x => new LibroViewModel(x.Id, x.Nombre, x.Autor, x.NumeroPaginas)).ToList(), totalCount);
        }

        public async Task<LibroViewModel> GetById(Guid id)
        {
            var data = await _repository.GetRepositoryAsync(id);
            if (data is null) throw new Exception($"No se encuentra el registro con el id {id}");
            return new LibroViewModel(data.Id, data.Nombre, data.Autor, data.NumeroPaginas);
        }

        public async Task<Guid> Registrar(LibroInputModel libroInputModel)
        {
            var data = new Libro { Autor = libroInputModel.Autor, Nombre = libroInputModel.Nombre, NumeroPaginas = libroInputModel.CantidadHojas };
            var data2 = await _repository.AddRepositoryAsync(data);
            return data2.Id;
        }
    }
}
