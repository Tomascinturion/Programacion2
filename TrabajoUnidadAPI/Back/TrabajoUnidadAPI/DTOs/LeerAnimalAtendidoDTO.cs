using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.DTOs
{
    public class LeerAnimalAtendidoDTO
    {
        public int IdAnimalatendido { get; set; }
        public string Nombre { get; set; }
        public string TipoAnimal { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }

        public int IdDueno { get; set; }
        public string NombreDueno { get; set; }
    }
}
