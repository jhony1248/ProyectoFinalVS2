using Microsoft.EntityFrameworkCore;
using Modelo.Escuela;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesos
{
    public class NotCreditoProc
    {
        public TiendaContext _context;

        public NotCreditoProc(TiendaContext context)
        {
            _context = context;
        }

        // Consulta la matrícula pendiente del estudiante y la valida

        // Registro de una matrícula
        static public NotCredito CreaNotCredito(
            TiendaContext context, string estado,
            DateTime fechaEmi, string LocNombre,
            string Descripcion,
            int FacId)
        {
            // 2.- Consulta del Local
            Local local = context.locals
                .Single(loc => loc.NombreLocal == LocNombre);
            // 3.- Consulta de la Factura
            Factura factura = context.Facturas
                .Single(fac => fac.FacturaId == FacId);
            // Datos de notas de credito
            NotCredito notCredito = new NotCredito()
            {
                FechaEmision = fechaEmi,
                NombreLocalE = LocNombre,
                Estado = estado,
                Descripcion = Descripcion,
                Factura = factura
            };

            return notCredito;
        }

        //Validadar Estado De la nota de credito
        public static bool NotCreditoAprobada(int notCreditoId)
        {
            bool aprobada = true;
            using (var db = new TiendaContext())
            {
                // Consulta a la configuración
                var configuracion = db.configuracion.Single();
                // Consulta de las matrículas pendientes
                var listaNotaCreditos = db.notCreditos
                    .Include(ntc => ntc.Factura)
                        .ThenInclude(fac => fac.Local)
                    .Include(ntc => ntc.Factura.TipoPago)
                    .Where(ntcs =>
                        ntcs.NotCreditoId == notCreditoId &&
                        ntcs.Estado == "Pendiente"
                    )
                    .ToList();
                // Revisa las reglas de negocio               
                foreach (var det in listaNotaCreditos)
                {
                    //variable de Nombre del local de la nota de credito
                    var notCre = det.NombreLocalE;
                    var locNom = det.Factura.Local.NombreLocal;
                    var tipoPag = det.Factura.TipoPago.NombreTipoPago;
                    var fechF = det.FechaEmision;
                    var fechI = det.Factura.FechaCompra;
                    var confiDias = configuracion.DiasMaxDev;
                    //si la nota de credito esta hecha en el mismo local de facturacion OK
                    //si el la tipo de pago no es una tarjeta de regalo tonces Ok
                    if (notCre == locNom && tipoPag != "Tarjeta de regalo")
                    {
                        //Verificar q la la devolucion se efectue dentro de los 15 dias de plazo
                        TimeSpan tspam = fechF - fechI;
                        int dias = tspam.Days;
                        if (dias> 0 && dias <= confiDias)
                        {
                            aprobada = true;
                        }
                        else
                        {
                            aprobada = false;
                        }
                    }
                    else
                    {
                        aprobada = false;
                    }
                }
            }
            return aprobada;
        }
        //Cierre NotCreditoAprobada


        public static float TotalDev(int notCreditoId)
        {
            var tot = 0f;
            using (var db = new TiendaContext())
            {
                // Consulta a la configuración
                var configuracion = db.configuracion.Single();
                var listaNotaCreditos = db.notCreditos
                     .Include(ntc => ntc.Factura)
                         .ThenInclude(fac => fac.Producto)
                     .Where(ntcs =>
                         ntcs.NotCreditoId == notCreditoId 
                     )
                     .ToList();
                foreach (var dett in listaNotaCreditos)
                {
                    var cantidad = dett.Factura.cantidad;
                    var precio = dett.Factura.Producto.Costo;
                    var Tpeso = configuracion.CostoPeso;
                    tot = (precio * cantidad)- Tpeso;
                    Console.WriteLine("Total a Devolver: " + tot);
                }
            }
            return tot;
        }
    }
}
