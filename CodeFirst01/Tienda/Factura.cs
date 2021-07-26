using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Escuela
{
    public class Factura : IDBEntity
    {
        public int FacturaId { get; set; }
        public DateTime FechaCompra { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public Producto Producto { get; set; }
        public int ProductoId { get; set; }
        public Local Local { get; set; }
        public int LocalId { get; set; }
        public TipoPago TipoPago { get; set; }
        public int TipoPagoId { get; set; }
        public int cantidad { get; set; }
        public List<NotCredito> NotCreditos { get; set; }
    }
}
