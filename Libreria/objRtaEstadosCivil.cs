using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class objRtaEstadosCivil
    {
        public bool ExisteError;
        public string MensajeError;
        public List<objEstadoCivil> EstadosCivil = new List<objEstadoCivil>();
    }
}
