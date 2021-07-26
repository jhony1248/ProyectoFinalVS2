using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Escuela
{
    public class Local : IDBEntity
    {
        public int LocalId { get; set; }
        public string NombreLocal { get; set; }
        public string DireccionLocal { get; set; }
        public List<Factura> Facturas { get; set; }
    }
}
