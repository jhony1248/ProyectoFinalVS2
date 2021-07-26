using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Escuela
{
    public class NotCredito : IDBEntity
    {
        public int NotCreditoId { get; set; }
        public DateTime FechaEmision { get; set; }
        public string NombreLocalE { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public Factura Factura { get; set; }
        public int FacturaId { get; set; }
    }
}
