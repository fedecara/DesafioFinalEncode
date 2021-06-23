using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
namespace CapaNegocio
{
    public class SuscriptorNegocio
    {
        SuscriptorDatos SuscriptorDatos = new SuscriptorDatos();

        public bool InsertarSuscriptor(Suscriptor sus)
        {
            return SuscriptorDatos.InsertarSuscriptor(sus);
        }
        
        public bool ActualizarSuscriptor(Suscriptor sus)
        {
            return SuscriptorDatos.ActualizarSuscriptor(sus);
        }
        
        public Suscriptor ConsultarSuscriptor(int TipoDocumento, long NumeroDocumento)
        {
            return SuscriptorDatos.ConsultarSuscriptor(TipoDocumento,NumeroDocumento);
        }
        public bool ExisteSuscriptor(Suscriptor sus)
        {
            return SuscriptorDatos.ExisteSuscriptor(sus);
        }

        public bool ExisteSuscripcion(Suscriptor sus)
        {
            return SuscriptorDatos.ExisteSuscripcion(sus);
        }

        public bool InsertarSuscripcion(Suscriptor sus, string FechaAlta)
        {
            return SuscriptorDatos.InsertarSuscripcion(sus, FechaAlta);
        }

    }
}
