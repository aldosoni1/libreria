using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InputModel
{
    public class LibroEditInputModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public int NumeroHojas { get; set; }
    }
}
