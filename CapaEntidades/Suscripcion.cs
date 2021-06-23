using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    class Suscripcion
    {
        public int IdAsociacion { get; set; }
        public int IdSuscriptor { get; set; }
        public String FechaAlta { get; set; }
        public DateTime FechaFin { get; set; }
        public String MotivoFin { get; set; }
    }
}
