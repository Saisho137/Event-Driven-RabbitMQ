using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicadorSistemaTransaccional
{
    public class Model
    {
        public string inscripcion { get; set; }
        public int cuentaOrigen { get; set; }
        public int cuentaInscrita { get; set; }
        public int cedulaTitular { get; set; }
        public string fechaInscripcion { get; set; }
    }
}
