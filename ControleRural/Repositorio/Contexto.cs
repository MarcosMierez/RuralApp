using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ControleRural.Repositorio
{
    public class Contexto
    {
        public static string getConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MYSQL_CONNECTION_STRING") ??
                   "Database=controlerural;Data Source=localhost;User Id=root; Password=root";
        }
        public Contexto()
        {
            SqlBd.Open();
        }

        public MySqlConnection SqlBd = new MySqlConnection(getConnectionString());
    }
}