using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CapaDatos
{



    public class Conexion
    {
        public Conexion()
        {
        }
        public string GetConex()
        {
            string strConex = ConfigurationManager.ConnectionStrings["CadenaBD"].ConnectionString;
            if (object.ReferenceEquals(strConex, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strConex;
            }
        }
    }


}


