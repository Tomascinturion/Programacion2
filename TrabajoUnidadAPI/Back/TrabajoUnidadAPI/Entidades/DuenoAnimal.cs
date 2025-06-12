using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Entidades
{
    public class DuenoAnimal
    {
        public int IdDuenoAnimal { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public ICollection<AnimalAtendido> AnimalAtendido { get; set; }
    }
}
