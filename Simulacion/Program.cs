using Persistencia;
using System.Linq;
using System;
using Modelo.Escuela;
using Escenarios;
using Procesos;
using Reportes;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Simulacion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Código para crear el escenario 1
            Escenario01 escenario = new Escenario01();
            EscenarioControl control = new EscenarioControl();
            control.Grabar(escenario);
            // Código para crear las Notas de Credito
            var datosNotCredito = new DatosNotCredito();
            datosNotCredito.Generar();

            //reglas de validacion
            using (var db = new TiendaContext())
            {
                var listaNotCreditos = db.notCreditos
                    .Include(fac => fac.Factura)
                        .ThenInclude(pro => pro.Producto)
                     .Include(facc => facc.Factura.Producto)
                    .Include(fact => fact.Factura.Cliente)
                    .Where(ntc => ntc.Estado == "Pendiente")
                    .ToList();
                Console.WriteLine("-------------Notas De Credito---------------");
                foreach (var notCredito in listaNotCreditos)
                {
                    Console.WriteLine(
                        String.Format(
                            "FacturaId: {0} NotCreditoId: {1} Cliente: {2} {3}  Producto: {4}  Total devuelto: {5}  Estado: {6} ",
                            notCredito.Factura.FacturaId,
                            notCredito.NotCreditoId,
                            notCredito.Factura.Cliente.NombreCliente,
                            notCredito.Factura.Cliente.ApellidoCliente,
                            notCredito.Factura.Producto.Modelo,
                            NotCreditoProc.TotalDev(notCredito.NotCreditoId),
                            NotCreditoProc.NotCreditoAprobada(notCredito.NotCreditoId) ? "Aprobada" : "Rechazada"
                        )
                    );
                }
                Console.WriteLine("--------------------------------------------------------");

                Reportes.Reporte.ReporteValidarNotCredito(1);
                Reportes.Reporte.ReporteValidarNotCredito(2);
                Reportes.Reporte.ReporteValidarNotCredito(3);
                Reportes.Reporte.ReporteValidarNotCredito(4);
                Reportes.Reporte.ReporteValidarNotCredito(5);

                //control de concurrencia

                /*
                db.Database.ExecuteSqlRaw(
                "UPDATE dbo.clientes SET NombreCliente = 'PruebaConcc' WHERE ClienteId = 2");
                */
                    try
                    {                      
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException exception)
                    {
                        Exception ex = new Exception("Conficto de concurrencia", exception);
                        throw ex;
                    }
            }
        }
    }
}

