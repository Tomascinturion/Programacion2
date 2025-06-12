using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Entidades
{
    public class AnimalAtendido
    {
        public int IdAnimalatendido { get; set; }
        public string Nombre { get; set; }
        public TipoAnimal IdTipoAnimal { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public int IdDuenoAnimal { get; set; }
        public DuenoAnimal DuenoAnimal { get; set; }
        public ICollection<Atencion> Atencion { get; set;}

    }
}
