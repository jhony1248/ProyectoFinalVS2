using Microsoft.EntityFrameworkCore;
using Modelo.Escuela;
using Persistencia;
using Procesos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes
{
    public class Reporte
    {

        // Reporte explicativo de la validación de la matrícula
        static public bool ReporteValidarNotCredito(int notCreditoId)
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
                    .Include(cli => cli.Factura.Cliente)
                    .Where(ntcs =>
                        ntcs.NotCreditoId == notCreditoId &&
                        ntcs.Estado == "Pendiente"
                    )
                    .ToList();
                Console.WriteLine(" ");               
                // Revisa las reglas de negocio               
                foreach (var det in listaNotaCreditos)
                {
                    Console.WriteLine("Análisis de la Nota de credito {0} de {1}",
                    det.NotCreditoId, det.Factura.Cliente.NombreCliente);
                    Console.WriteLine("--------------------------------------------");
                    //variable de Nombre del local de la nota de credito
                    var notCre = det.NombreLocalE;
                    var locNom = det.Factura.Local.NombreLocal;
                    var tipoPag = det.Factura.TipoPago.NombreTipoPago;
                    var fechF = det.FechaEmision;
                    var fechI = det.Factura.FechaCompra;
                    var confiDias = configuracion.DiasMaxDev;
                    //si la nota de credito esta hecha en el mismo local de facturacion OK
                    //si el la tipo de pago no es una tarjeta de regalo tonces Ok
                    if (notCre != locNom)
                    {
                        Console.WriteLine("--Local de compra: " + notCre + " y Local donde se hace la devolucion: " + locNom);
                        Console.WriteLine("--El local donde se hace la devolucion Es diferente al local donde se hizo la compra");
                        aprobada = false;
                    }
                    else
                    {
                        Console.WriteLine("--Local de compra y devolucion: " + notCre);
                        Console.WriteLine("--El local donde se hace la devolucion es igual al local donde se hizo la compra");
                        Console.WriteLine("");
                        if (tipoPag == "Tarjeta de regalo")
                        {
                            Console.WriteLine("--El tipo de pago que se realizo en la factura: " + tipoPag);
                            Console.WriteLine("--El tipo de pago a sido Rechazado"); ;
                            aprobada = false;
                        }
                        else {
                            Console.WriteLine("--El tipo de pago que se realizo en la factura: " + tipoPag);
                            Console.WriteLine("--El tipo de pago a sido Aceptado");
                            Console.WriteLine("");
                            TimeSpan tspam = fechF - fechI;
                            int dias = tspam.Days;
                            if (dias >= confiDias)
                            {
                                Console.WriteLine("--La fecha que se realizo la compra es: " + fechI);
                                Console.WriteLine("--La fecha que se realizo la devolucion es: " + fechF);
                                Console.WriteLine("--Los dias que han pasado desde la facturacion: " + dias + " Dias " +
                                    " y tiene como maximo: "+ confiDias + " Dias para hacer la devolucion");
                                aprobada = false;
                            }
                            else
                            {
                                Console.WriteLine("--La fecha que se realizo la compra es: " + fechI);
                                Console.WriteLine("--La fecha que se realizo la devolucion es: " + fechF);
                                Console.WriteLine("--Los dias que han pasado desde la facturacion: " + dias + " Dias " +
                                    " Estan dentro del plazo de : " + confiDias + " Dias para hacer la devolucion");
                                aprobada = true;
                            }
                        }              
                    }
                }
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("   RESULTADO: La Nota de Credito es {0}", aprobada ? "ACEPTADA" : "RECHAZADA");
            return aprobada;
        }
    }
}