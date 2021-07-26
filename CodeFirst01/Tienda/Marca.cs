using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Escuela
{
    public class Marca :IDBEntity
    {
        public int MarcaId { get; set; }
        public string MarcaNombre { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
