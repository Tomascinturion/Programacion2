using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.DTOs
{
    public class EditarAnimalAtendidoDTO
    {
        [Required]
        public int IdAnimalAtendido { get; set; }
        public string Nombre {  get; set; }
        public string Raza { get; set; }
        public int Edad {  get; set; }
        public string Sexo {  get; set; }

    }
}
