using PJENL.Shared.Kernel.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class LibreriaViewModel : ICatalogoInt
    {
        public string Descripcion { get; set; }
        public int Id { get; set; }
    }
}
