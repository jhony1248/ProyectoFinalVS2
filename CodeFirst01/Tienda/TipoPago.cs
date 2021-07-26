using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Escuela
{
    public class TipoPago : IDBEntity
    {
        public int TipoPagoId { get; set; }
        public string NombreTipoPago { get; set; }
        public string Descripcion { get; set; }
        public List<Factura> Facturas { get; set; }
    }
}
