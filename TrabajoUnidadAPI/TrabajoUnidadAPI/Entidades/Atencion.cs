using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Entidades
{
    public class Atencion
    {
        public int IdAtencion { get; set; }
        public AnimalAtendido AnimalAtendido { get; set; }
        public string Motivo { get; set; }
        public string Tratamiento { get; set; }
        public string Medicamentos { get; set; }
        public DateTime? FechaAtencion { get; set; }
    }
}
