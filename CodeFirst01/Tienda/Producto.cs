using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Escuela
{
    public class Producto : IDBEntity
    {
        public int ProductoId { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }
        public float Costo { get; set; }
        public Marca Marca { get; set; }
        public int MarcaId { get; set; }
        public List<Factura> Facturas { get; set; }
    }
}
