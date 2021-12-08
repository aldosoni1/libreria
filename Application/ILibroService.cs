using Application.InputModel;
using Application.ViewModel;
using PJENL.Shared.Kernel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ILibroService
    {
        public Task<Guid> Registrar(LibroInputModel libroInputModel);
        public Task<GridResponse<IEnumerable<LibroViewModel>,LibroViewModel>> GetAll(string searchValue = null, int skip=0, int take =10);
        public Task<LibroViewModel> GetById(Guid id);
        public Task<LibroViewModel> Actualizar(LibroEditInputModel editInputModel);
        public Task<bool> Eliminar(Guid id);
    }
}
