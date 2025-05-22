using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaTrabajoUnidadAPI.DTOs
{
    public class CrearAtencionDTO
    {
        [Required]
        public int IdAnimalAtendido { get; set; }
        [Required] 
        public string Motivo { get; set; }
        [Required]
        public string Tratamiento { get; set; }
        [Required]
        public string Medicamentos { get; set; }
        public DateTime? FechaAtencion { get; set; }
    }
}
