using ConsolaTrabajoUnidadAPI.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsolaTrabajoUnidadAPI.Metodos.Animales;

namespace ConsolaTrabajoUnidadAPI.DTOs
{
    public class LecturaAnimalDTO
    {
        public int IdAnimalatendido { get; set; }
        public string Nombre { get; set; }
        public TipoAnimal IdTipoAnimal { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string DniDuenoAnimal { get; set; }
        
    }
}
