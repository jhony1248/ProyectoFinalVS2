using Escenarios;
using Modelo.Escuela;
using Persistencia;
using Procesos;
using Simulacion;
using Xunit;

namespace XUnitTestEscuela
{
    public class NotaCreditoEsValida
    {

        // Pruebas cualitativas
        [Theory]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(5, true)]
        [InlineData(6, false)]

        public void Fechas15(int ntcreId, bool resEsperado)
        {
            bool resultado;
            using (var context = new TiendaContext())
            {
                Configuracion config = context.configuracion.Find(1);
                config.DiasMaxDev = 15;
                context.SaveChanges();
                resultado = NotCreditoProc.NotCreditoAprobada(ntcreId);
            }
            if (resEsperado)
                Assert.True(resultado);
            else
                Assert.False(resultado);
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(5, true)]
        [InlineData(6, false)]

        public void FechasMax55(int ntcreId, bool resEsperado)
        {
            bool resultado;
            using (var context = new TiendaContext())
            {
                Configuracion config = context.configuracion.Find(1);
                config.DiasMaxDev = 55;
                context.SaveChanges();

                resultado = NotCreditoProc.NotCreditoAprobada(ntcreId);
            }
            if (resEsperado)
                Assert.True(resultado);
            else
                Assert.False(resultado);
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        [InlineData(6, false)]

        public void FechasMax8(int ntcreId, bool resEsperado)
        {
            bool resultado;
            using (var context = new TiendaContext())
            {
                Configuracion config = context.configuracion.Find(1);
                config.DiasMaxDev = 8;
                context.SaveChanges();

                resultado = NotCreditoProc.NotCreditoAprobada(ntcreId);
            }
            if (resEsperado)
                Assert.True(resultado);
            else
                Assert.False(resultado);
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(5, true)]
        [InlineData(6, false)]

        public void FechasSinMax(int ntcreId, bool resEsperado)
        {
            bool resultado;
            using (var context = new TiendaContext())
            {
                Configuracion config = context.configuracion.Find(1);
                config.DiasMaxDev = 100000000;
                context.SaveChanges();

                resultado = NotCreditoProc.NotCreditoAprobada(ntcreId);
            }
            if (resEsperado)
                Assert.True(resultado);
            else
                Assert.False(resultado);
        }

        // Pruebas cuantitativas
        [Theory]
        [InlineData(1, 1190)]
        [InlineData(2, 1190)]
        [InlineData(3, 2390)]
        [InlineData(4, 830)]
        [InlineData(5, 410)]
        [InlineData(6, 3840)]

        public void TotalPagar10(int ntcreId, float resEsperado)
        {
            var resultado = 0f;
            using (var context = new TiendaContext())
            {
                Configuracion config = context.configuracion.Find(1);
                config.CostoPeso = 10;
                context.SaveChanges();

                resultado = NotCreditoProc.TotalDev(ntcreId);
            }
            Assert.True(resEsperado == resultado);
        }

        [Theory]
        [InlineData(1, 1170)]
        [InlineData(2, 1170)]
        [InlineData(3, 2370)]
        [InlineData(4, 810)]
        [InlineData(5, 390)]
        [InlineData(6, 3820)]

        public void TotalPagarPeso30(int notCreditoId, float resEsperado)
        {
            var resultado = 0f;
            using (var context = new TiendaContext())
            {
                Configuracion config = context.configuracion.Find(1);
                config.CostoPeso = 30;
                context.SaveChanges();

                resultado = NotCreditoProc.TotalDev(notCreditoId);
            }
            Assert.True(resEsperado == resultado);
        }

        [Theory]
        [InlineData(1, 1100)]
        [InlineData(2, 1100)]
        [InlineData(3, 2300)]
        [InlineData(4, 740)]
        [InlineData(5, 320)]
        [InlineData(6, 3750)]

        public void TotalPagarPeso100(int notCreditoId, float resEsperado)
        {
            var resultado = 0f;
            using (var context = new TiendaContext())
            {
                Configuracion config = context.configuracion.Find(1);
                config.CostoPeso = 100;
                context.SaveChanges();

                resultado = NotCreditoProc.TotalDev(notCreditoId);
            }
            Assert.True(resEsperado == resultado);
        }

        [Theory]
        [InlineData(1, 1200)]
        [InlineData(2, 1200)]
        [InlineData(3, 2400)]
        [InlineData(4, 840)]
        [InlineData(5, 420)]
        [InlineData(6, 3850)]
        public void TotalPagarSinPeso(int notCreditoId, float resEsperado)
        {
            var resultado = 0f;
            using (var context = new TiendaContext())
            {
                Configuracion config = context.configuracion.Find(1);
                config.CostoPeso = 0;
                context.SaveChanges();

                resultado = NotCreditoProc.TotalDev(notCreditoId);
            }
            Assert.True(resEsperado == resultado);
        }

    }
}
