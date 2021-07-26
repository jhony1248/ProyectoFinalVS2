using Escenarios;
using Modelo.Escuela;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Escenarios.Escenario;

namespace Simulacion
{
    public class EscenarioControl
    {
        public void Grabar(IEscenario escenario)
        {
            var datos = escenario.Carga();

            using (var db = new TiendaContext())
            {
                // Reiniciamos la base de datos
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                // Insertamos los datos
                db.configuracion.AddRange       ((List<Configuracion>)    datos[ListaTipo.Configuracion]);
                db.clientes.AddRange            ((List<Cliente>)          datos[ListaTipo.Clientes]);
                db.locals.AddRange              ((List<Local>)            datos[ListaTipo.Locals]);
                db.tipoPagos.AddRange           ((List<TipoPago>)         datos[ListaTipo.TipoPagos]);
                db.Marcas.AddRange              ((List<Marca>)            datos[ListaTipo.Marcas]);
                db.productos.AddRange           ((List<Producto>)         datos[ListaTipo.Productos]);
                db.Facturas.AddRange            ((List<Factura>)          datos[ListaTipo.Facturas]);
                // Genera la persistencia
                db.SaveChanges();
            }
        }
    }
}
