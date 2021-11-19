using Application.InputModel;
using Application.ViewModel;
using Domain.Models.Repositories;
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
            var data = await _repository.GetById(editInputModel.Id);
            data.Nombre = editInputModel.Nombre;
            data.NumeroPaginas = editInputModel.NumeroHojas;
            data.Autor = editInputModel.Autor;
            await _repository.Actualizar(data);
            return new LibroViewModel(data.Id,data.Nombre,data.Autor,data.NumeroPaginas);
        }

        public Task<Guid> Eliminar(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LibroViewModel>> GetAll(string searchValue = null, int skip = 0, int take = 10)
        {
            var data = await _repository.GetLibros(searchValue, skip, take);
            return data.Select(x => new LibroViewModel(x.Id, x.Nombre, x.Autor, x.NumeroPaginas));
        }

        public Task<LibroViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Registrar(LibroInputModel libroInputModel)
        {
            throw new NotImplementedException();
        }
    }
}
