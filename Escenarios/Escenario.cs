using Modelo;

using System.Collections.Generic;


namespace Escenarios
{
    public class Escenario
    {
        public enum ListaTipo {
            Clientes,
            Configuracion,
            Locals,
            TipoPagos,
            Productos,
            Marcas,
            Facturas}

        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> datos;        

        public Escenario()
        {
            datos = new();
        }
    }
}
