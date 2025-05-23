using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaTrabajoUnidadAPI.DTOs
{
    public class EditarAnimalAtendidoDTO
    {
        [Required]
        public int idanimalatendido { get; set; }
        public string nombre {  get; set; }
        public string raza { get; set; }
        public int edad {  get; set; }
        public string sexo {  get; set; }

    }
}
