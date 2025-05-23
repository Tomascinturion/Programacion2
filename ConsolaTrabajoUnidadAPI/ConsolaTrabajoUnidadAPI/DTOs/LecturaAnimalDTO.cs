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
            public int idAnimalatendido { get; set; }
            public string nombre { get; set; }
            public string tipoAnimal { get; set; }
            public string raza { get; set; }
            public int edad { get; set; }
            public string sexo { get; set; }

            public int idDueno { get; set; }
            public string nombreDueno { get; set; }

    }
}
