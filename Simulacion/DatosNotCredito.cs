using Microsoft.EntityFrameworkCore;
using Modelo.Escuela;
using Persistencia;
using Procesos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    public class DatosNotCredito
    {
        // Estados de la matrícula
        public enum NotCredEstados { Pendiente, Aprobada, Rechazada };
        public void Generar()
        {
            // Nota de credito de la factura1
            // Fecha Devolucion
            // Rechazado po tipo de pago
            DateTime fechaEmi = new DateTime(2020, 2, 25);
            // Local
            string LocNombre = "LOSAN-BLAS";
            // Descripcion de la nota de credito
            string Descripcion = "Producto devuelto por falla en suela";
            int FacId = 1;
            // Notas De Credito
            NotCredito cev1;

            // Persistencia 
            using (var db = new TiendaContext())
            {
                cev1 = NotCreditoProc.CreaNotCredito(db,
                    NotCredEstados.Pendiente.ToString(), fechaEmi, LocNombre, Descripcion, FacId);
                try
                {
                    db.notCreditos.Add(cev1);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException exception)
                {
                    Exception ex = new Exception("Conficto de concurrencia", exception);
                    throw ex;
                }
                
            }
            //----------------------------------------------------------------------------------------------
            // Nota de credito de la factura2
            // Fecha Devolucion
            // Rechazado por fecha dev mayor a 15
            fechaEmi = new DateTime(2020, 3, 05);
            // Local
            LocNombre = "LOS-RECREO";
            // Descripcion de la nota de credito
            Descripcion = "Producto devuelto por falla en cuero";
            FacId = 2;
            // Notas De Credito
            NotCredito cev2;

            // Persistencia 
            using (var db = new TiendaContext())
            {
                cev2 = NotCreditoProc.CreaNotCredito(db,
                    NotCredEstados.Pendiente.ToString(), fechaEmi, LocNombre, Descripcion, FacId);
                db.notCreditos.Add(cev2);
                db.SaveChanges();
            }
            //----------------------------------------------------------------------------------------------

            //Nota de credito de la factura3
            // Fecha Devolucion
            // Error por devolucion en local diferente al de emision
            fechaEmi = new DateTime(2020, 2, 28);
            // Local
            LocNombre = "LOSLUCHA-POB";
            // Descripcion de la nota de credito
            Descripcion = "Producto devuelto por falla en cuero";
            FacId = 3;
            // Notas De Credito
            NotCredito cev3;

            // Persistencia 
            using (var db = new TiendaContext())
            {
                cev3 = NotCreditoProc.CreaNotCredito(db,
                    NotCredEstados.Pendiente.ToString(), fechaEmi, LocNombre, Descripcion, FacId);
                db.notCreditos.Add(cev3);
                db.SaveChanges();
            }
            //----------------------------------------------------------------------------------------------

            //Nota de credito de la factura4
            // Fecha Devolucion
            fechaEmi = new DateTime(2020, 1, 29);
            // Local
            LocNombre = "LOSAN-BLAS";
            // Descripcion de la nota de credito
            Descripcion = "Producto devuelto por falla en suela";
            FacId = 5;
            // Notas De Credito
            NotCredito cev4;

            // Persistencia 
            using (var db = new TiendaContext())
            {
                cev4 = NotCreditoProc.CreaNotCredito(db,
                    NotCredEstados.Pendiente.ToString(), fechaEmi, LocNombre, Descripcion, FacId);
                db.notCreditos.Add(cev4);
                db.SaveChanges();
            }
            //----------------------------------------------------------------------------------------------

            //Nota de credito de la factura5
            // Fecha Devolucion
            fechaEmi = new DateTime(2020, 2, 15);
            // Local
            LocNombre = "LOS-PUJILI";
            // Descripcion de la nota de credito
            Descripcion = "Producto devuelto por falla en talla";
            FacId = 6;
            // Notas De Credito
            NotCredito cev5;

            // Persistencia 
            using (var db = new TiendaContext())
            {
                cev5 = NotCreditoProc.CreaNotCredito(db,
                    NotCredEstados.Pendiente.ToString(), fechaEmi, LocNombre, Descripcion, FacId);
                db.notCreditos.Add(cev5);
                db.SaveChanges();
            }
            //----------------------------------------------------------------------------------------------

            //Nota de credito de la factura5
            // Fecha Devolucion
            fechaEmi = new DateTime(2020, 4, 02);
            // Local
            LocNombre = "LOS-PUJILI";
            // Descripcion de la nota de credito
            Descripcion = "Producto devuelto por falla en calzado";
            FacId = 4;
            // Notas De Credito
            NotCredito cev6;

            // Persistencia 
            using (var db = new TiendaContext())
            {
                cev6 = NotCreditoProc.CreaNotCredito(db,
                    NotCredEstados.Pendiente.ToString(), fechaEmi, LocNombre, Descripcion, FacId);
                db.notCreditos.Add(cev6);
                db.SaveChanges();
            }
            //----------------------------------------------------------------------------------------------
        }
    }
}
