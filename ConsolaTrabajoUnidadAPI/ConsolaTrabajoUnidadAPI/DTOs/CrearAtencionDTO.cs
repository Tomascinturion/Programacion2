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
        public int idanimalatendido { get; set; }
        [Required] 
        public string motivo { get; set; }
        [Required]
        public string tratamiento { get; set; }
        [Required]
        public string medicamentos { get; set; }
        public DateTime? fechaatencion { get; set; }
    }
}
