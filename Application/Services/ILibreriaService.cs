using PJENL.Shared.Kernel.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ILibreriaService
    {
        Task<IEnumerable<ICatalogoInt>> GetAll(string searchValue = null, int skip = 0, int take = 10);
    }
}
