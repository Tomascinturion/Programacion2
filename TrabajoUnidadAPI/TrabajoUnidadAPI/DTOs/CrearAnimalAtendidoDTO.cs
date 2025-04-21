using CDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.DTOs
{
    public class CrearAnimalAtendidoDTO
    {
        public string Nombre { get; set; }
        public TipoAnimal IdTipoAnimal { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public int DniDuenoAnimal { get; set; }
    }
}
