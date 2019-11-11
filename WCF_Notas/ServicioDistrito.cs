using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity.Core;

namespace WCF_Notas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioDistrito" en el código y en el archivo de configuración a la vez.
    public class ServicioDistrito : IServicioDistrito
    {
        public List<Distrito> GetAllDistrito()
        {
            ISILNotasEntities MiDistrito = new ISILNotasEntities();
            List<Distrito> objListaDistrito = new List<Distrito>();
            try
            {
                var query = (from objDistrito in MiDistrito.DISTRITO
                             orderby objDistrito.id_distrito select objDistrito);
                foreach(var resultado in query)
                {
                    Distrito objDistrito = new Distrito();
                    objDistrito.IdDistrito = resultado.id_distrito;
                    objDistrito.Nombre = resultado.nombre;
                    objListaDistrito.Add(objDistrito);
                }
                return objListaDistrito;
            }
            catch(EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
