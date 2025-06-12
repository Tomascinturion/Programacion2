using CDatos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.DTOs
{
    public class CrearAnimalAtendidoDTO
    {
        //[Required]
        public string Nombre { get; set; }
        //[Required]
        public TipoAnimal IdTipoAnimal { get; set; }
        //[Required]
        public string Raza { get; set; }
        //[Range(0, 100)]
        public int Edad { get; set; }
        //[Required]
        public string Sexo { get; set; }
        //[Required]
        public int DniDuenoAnimal { get; set; }
    }
}
