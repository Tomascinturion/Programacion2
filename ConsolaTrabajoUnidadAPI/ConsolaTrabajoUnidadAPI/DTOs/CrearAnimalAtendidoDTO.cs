using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsolaTrabajoUnidadAPI.Metodos.Animales;

namespace ConsolaTrabajoUnidadAPI.DTOs
{
    public class CrearAnimalAtendidoDTO
    {
        //[Required]
        public string nombre { get; set; }
        //[Required]
        public TipoAnimal idtipoanimal { get; set; }
        //[Required]
        public string raza { get; set; }
        //[Range(0, 100)]
        public int edad { get; set; }
        //[Required]
        public string sexo { get; set; }
        //[Required]
        public int dniduenoanimal { get; set; }
    }
}
