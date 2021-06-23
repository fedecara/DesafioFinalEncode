using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Suscriptor
    {
        public int IdSuscriptor { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public long NumeroDocumento { get; set; }
        public int TipoDocumento { get; set; }
        public string Direccion { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public String NombreUsuario { get; set; }
        public string Password { get; set; }
    }
}
