using PERSISTENCIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class PersonaBC
    {
        public bool validacionConexion()
        {
            return new PersonaDAC().ValidacionConexion();
        }


    }


}
