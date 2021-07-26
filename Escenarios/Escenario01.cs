using Modelo;
using Modelo.Escuela;
using System;
using System.Collections.Generic;
using static Escenarios.Escenario;

namespace Escenarios
{
    public class Escenario01 : Escenario, IEscenario
    {
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> Carga()
        {
            // .- Creación de los Clientes
            Cliente jhony = new() { NombreCliente = "Jhony", ApellidoCliente = "Hurtado" };
            Cliente Anthony = new() { NombreCliente = "Anthony", ApellidoCliente = "Villaroel" };
            Cliente Adrian = new() { NombreCliente = "Adrian", ApellidoCliente = "Chicaiza" };
            Cliente Abii = new() { NombreCliente = "Abigail", ApellidoCliente = "Iza" };
            Cliente Evelyn = new() { NombreCliente = "Evelyn", ApellidoCliente = "Pilataxi" };
            Cliente Maria = new() { NombreCliente = "Maria", ApellidoCliente = "Borja" };
            Cliente Pedro = new() { NombreCliente = "Pedro", ApellidoCliente = "Macias" };
            Cliente Juan = new() { NombreCliente = "Juan", ApellidoCliente = "Aros" };
            List<Cliente> listaClientes = new() { jhony, Anthony, Adrian, Abii, Evelyn, Maria, Pedro, Juan };
            datos.Add(ListaTipo.Clientes, listaClientes);

            // .- Configuración de los datos de la Tienda
            Configuracion configuracion = new()
            {
                NombreEmpresa = "Tienda Mil Pasos",
                DiasMaxDev = 15,
                CostoPeso = 10f
            };
            List<Configuracion> listaConfiguracion = new() { configuracion };
            datos.Add(ListaTipo.Configuracion, listaConfiguracion);

            // .- Registro de los Locales
            Local Local1 = new() { NombreLocal = "LOSAN-BLAS", DireccionLocal = "San Blas" };
            Local Local2 = new() { NombreLocal = "LOSAN-BARTOLO", DireccionLocal = "San Blas" };
            Local Local3 = new() { NombreLocal = "LOS-ARGELIA", DireccionLocal = "La Argelia" };
            Local Local4 = new() { NombreLocal = "LOS-RECREO", DireccionLocal = "El Recreo" };
            Local Local5 = new() { NombreLocal = "LOS-PUJILI", DireccionLocal = "Pujili" };
            Local Local6 = new() { NombreLocal = "LOSLUCHA-POB", DireccionLocal = "Lucha de los pobres" };
            Local Local7 = new() { NombreLocal = "LOS-CHILLOGALLO", DireccionLocal = "Chillogallo" };
            Local Local8 = new() { NombreLocal = "LOS-AJAVI", DireccionLocal = "AJAVI" };
            Local Local9 = new() { NombreLocal = "LOSNAC-UNIDADAS", DireccionLocal = "Naciones Unidas" };
            List<Local> lstlocales = new() { Local1, Local2, Local3, Local4, Local5, Local6, Local7, Local8, Local9 };
            datos.Add(ListaTipo.Locals, lstlocales);

            // .- Registro de los Tipos de pagos
            TipoPago Efectivo = new() { NombreTipoPago = "Efectivo", Descripcion = "Pago en Efectivo" };
            TipoPago TarCredito = new() { NombreTipoPago = "Tarjeta Credito", Descripcion = "Pago con tarjeta de credito" };
            TipoPago TraBancaria = new() { NombreTipoPago = "Transferencia Bancaria", Descripcion = "Pago con Transferencia Bancaria" };
            TipoPago PayPal = new() { NombreTipoPago = "PayPal", Descripcion = "Pago con PayPal" };
            TipoPago Cheque = new() { NombreTipoPago = "Cheque", Descripcion = "Pago con Cheque" };
            TipoPago TarjetaRegalo = new() { NombreTipoPago = "Tarjeta de regalo", Descripcion = "Pago con Tarjeta de regalo" };
            List<TipoPago> listaTipoPago = new() { Efectivo, TarCredito, TraBancaria, PayPal, Cheque, TarjetaRegalo };
            datos.Add(ListaTipo.TipoPagos, listaTipoPago);

            // .- Registro de la Marca
            Marca Nike = new() { MarcaNombre = "Nike" };
            Marca Converse = new() { MarcaNombre = "Converse" };
            Marca Puma = new() { MarcaNombre = "Puma" };
            Marca Gucci = new() { MarcaNombre = "Gucci" };
            Marca ABC = new() { MarcaNombre = "ABC" };
            Marca LioJo = new() { MarcaNombre = "Lio-Jo" };
            Marca LEVIS = new() { MarcaNombre = "LEVI'S" };
            Marca MOD8 = new() { MarcaNombre = "MOD 8" };
            Marca Adidas = new() { MarcaNombre = "Adidas" };
            List<Marca> listaMarca = new() { Nike, Converse, Puma, Gucci, ABC, LioJo, LEVIS, MOD8, Adidas };
            datos.Add(ListaTipo.Marcas, listaMarca);

            //.- Registro de los Productos
            Producto prod1 = new() { Modelo = "Air Jordan 19", Color = "Rojo", Stock = 55, Costo = 210, Marca = Adidas };
            Producto prod2 = new() { Modelo = "Air Pegasus 0212", Color = "Blanco", Stock = 80, Costo = 150, Marca = Adidas };
            Producto prod3 = new() { Modelo = "CortezXO25", Color = "Azul", Stock = 55, Costo = 210, Marca = Adidas };
            Producto prod4 = new() { Modelo = "AS 98", Color = "Rojo", Stock = 10, Costo = 150, Marca = Adidas };
            Producto prod5 = new() { Modelo = "Buffalo", Color = "Rojo", Stock = 15, Costo = 300, Marca = LioJo };
            Producto prod6 = new() { Modelo = "Duuo", Color = "Amarillo", Stock = 30, Costo = 350, Marca = ABC };
            Producto prod7 = new() { Modelo = "EDWARD'S", Color = "Amarillo", Stock = 53, Costo = 400, Marca = ABC };
            Producto prod8 = new() { Modelo = "Fila", Color = "Amarillo", Stock = 35, Costo = 150, Marca = Gucci };
            Producto prod9 = new() { Modelo = "Polaris", Color = "Verde", Stock = 55, Costo = 210, Marca = Gucci };
            Producto prod10 = new() { Modelo = "Yellow", Color = "Verde", Stock = 55, Costo = 215, Marca = Gucci };
            Producto prod11 = new() { Modelo = "Xiccs", Color = "Verde", Stock = 100, Costo = 230, Marca = Puma };
            Producto prod12 = new() { Modelo = "Aquazzura", Color = "Verde", Stock = 300, Costo = 280, Marca = Puma };
            Producto prod13 = new() { Modelo = "Weitzman", Color = "Azul", Stock = 58, Costo = 260, Marca = Converse };
            Producto prod14 = new() { Modelo = "Corthay", Color = "Azul", Stock = 50, Costo = 140, Marca = Converse };
            Producto prod15 = new() { Modelo = "Dunk High sb25", Color = "Azul", Stock = 100, Costo = 140, Marca = LEVIS };
            Producto prod16 = new() { Modelo = "Air34", Color = "Azul", Stock = 150, Costo = 300, Marca = LEVIS };
            Producto prod17 = new() { Modelo = "RST93", Color = "Blanco", Stock = 180, Costo = 500, Marca = MOD8 };
            Producto prod18 = new() { Modelo = "Alden", Color = "Blanco", Stock = 190, Costo = 550, Marca = MOD8 };
            Producto prod19 = new() { Modelo = "Corthay", Color = "Blanco", Stock = 300, Costo = 300, Marca = Puma };
            Producto prod20 = new() { Modelo = "Cressy", Color = "Blanco", Stock = 400, Costo = 105, Marca = Puma };
            List<Producto> listaProducto = new()
            {
                prod1, prod2, prod3, prod4, prod5, prod6, prod7,  prod8,  prod9,  prod10, prod11, 
                prod12, prod13, prod14, prod15, prod16, prod17, prod18, prod19, prod20,
            };
            datos.Add(ListaTipo.Productos, listaProducto);

            //.- Registro de las Facturas
            Factura factura1 = new()
            {
                FechaCompra = new DateTime(2020, 1, 25),
                Cliente = jhony,
                Producto = prod1,
                Local = Local1,
                TipoPago = Efectivo,
                cantidad = 4
            };
            Factura factura2 = new()
            {
                FechaCompra = new DateTime(2020, 1, 25),
                Cliente = Abii,
                Producto = prod5,
                Local = Local4,
                TipoPago = TraBancaria,
                cantidad = 4
            };
            Factura factura3 = new()
            {
                FechaCompra = new DateTime(2020, 2, 1),
                Cliente = jhony,
                Producto = prod1,
                Local = Local5,
                TipoPago = TarCredito,
                cantidad = 2
            };
            Factura factura4 = new()
            {
                FechaCompra = new DateTime(2020, 2, 19),
                Cliente = Juan,
                Producto = prod7,
                Local = Local1,
                TipoPago = TarjetaRegalo,
                cantidad = 3
            };
            Factura factura5 = new()
            {
                FechaCompra = new DateTime(2020, 2, 20),
                Cliente = Anthony,
                Producto = prod16,
                Local = Local8,
                TipoPago = PayPal,
                cantidad = 8
            };

            Factura factura6 = new()
            {
                FechaCompra = new DateTime(2020, 2, 20),
                Cliente = Maria,
                Producto = prod18,
                Local = Local6,
                TipoPago = PayPal,
                cantidad = 7
            };

            List<Factura> listaFactura = new() { factura1, factura2, factura3, factura4, factura5 , factura6 };
            datos.Add(ListaTipo.Facturas, listaFactura);

            // Retorna el diccionario 
            return datos;
        }

    }
}