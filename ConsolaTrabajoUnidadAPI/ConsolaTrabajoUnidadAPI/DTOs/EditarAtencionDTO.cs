using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaTrabajoUnidadAPI.DTOs
{
    public class EditarAtencionDTO
    {
        [Required]
        public int IdAtencion { get; set; }
        public string Motivo { get; set; }
        public string Tratamiento { get; set; }
        public string Medicamentos { get; set; }
        public DateTime? FechaAtencion { get; set; }
    }
}
