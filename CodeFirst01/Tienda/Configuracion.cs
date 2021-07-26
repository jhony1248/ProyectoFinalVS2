using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Escuela
{
    public class Configuracion : IDBEntity
    {
        public int ConfiguracionId { get; set; }
        public string NombreEmpresa { get; set; }
        public int DiasMaxDev { get; set; }
        public float CostoPeso { get; set; }
    }
}
