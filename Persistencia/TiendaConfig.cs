using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace Persistencia
{
    public class TiendaConfig
    {
        public enum DestinoTipo { SQLServerProyecto, PostgresProyecto, MemoryProyecto };
        const string KeyPersistenciaDestino = "PersistenciaDestino";
        static DestinoTipo PersistenciaDestino;
        static string StringConnection;

        static TiendaConfig()
        {
            if (String.IsNullOrEmpty(StringConnection))
            {
                // Lectura de los parámetros del sistema
                PersistenciaDestino = (DestinoTipo)Enum.Parse(typeof(DestinoTipo), ConfigurationManager.AppSettings[KeyPersistenciaDestino].ToString());
                StringConnection = ConfigurationManager.ConnectionStrings[PersistenciaDestino.ToString()].ToString();
                // Debug
                Console.WriteLine(PersistenciaDestino + " --> " + StringConnection);
            }
        }

        static public void ContextOptions(DbContextOptionsBuilder optionsBuilder)
        {
            switch (PersistenciaDestino)
            {
                case DestinoTipo.SQLServerProyecto:
                    optionsBuilder.UseSqlServer(StringConnection);
                    break;
                case DestinoTipo.PostgresProyecto:
                    optionsBuilder.UseNpgsql(StringConnection);
                    break;
                case DestinoTipo.MemoryProyecto:
                    optionsBuilder.UseInMemoryDatabase(StringConnection);
                    break;
                default:
                    break;
            }
        }

    }
}