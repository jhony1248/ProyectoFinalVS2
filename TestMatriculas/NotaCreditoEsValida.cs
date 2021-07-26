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

        public void Fechas15(int factId, bool resEsperado)
        {
            bool resultado;
            using (var context = new TiendaContext())
            {
                Configuracion config = context.configuracion.Find(1);
                config.DiasMaxDev = 15;
                context.SaveChanges();
                resultado = NotCreditoProc.NotCreditoAprobada(factId);
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

        public void FechasMax55(int factId, bool resEsperado)
        {
            bool resultado;
            using (var context = new TiendaContext())
            {
                Configuracion config = context.configuracion.Find(1);
                config.DiasMaxDev = 55;
                context.SaveChanges();

                resultado = NotCreditoProc.NotCreditoAprobada(factId);
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

        public void FechasMax8(int factId, bool resEsperado)
        {
            bool resultado;
            using (var context = new TiendaContext())
            {
                Configuracion config = context.configuracion.Find(1);
                config.DiasMaxDev = 8;
                context.SaveChanges();

                resultado = NotCreditoProc.NotCreditoAprobada(factId);
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

        public void TotalPagar10(int notCreditoId, float resEsperado)
        {
            var resultado = 0f;
            using (var context = new TiendaContext())
            {
                Configuracion config = context.configuracion.Find(1);
                config.CostoPeso = 10;
                context.SaveChanges();

                resultado = NotCreditoProc.TotalDev(notCreditoId);
            }
            Assert.True(resEsperado == resultado);
        }

        [Theory]
        [InlineData(1, 1170)]
        [InlineData(2, 1170)]
        [InlineData(3, 2370)]
        [InlineData(4, 810)]
        [InlineData(5, 390)]

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
