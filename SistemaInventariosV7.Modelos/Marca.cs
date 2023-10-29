using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventariosV7.Modelos
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(60, ErrorMessage = "Nombre debe de tener máximo 60 Caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Descripción es requerido")]
        [MaxLength(100, ErrorMessage = "Nombre debe de tener máximo 100 Caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Estado es requerido")]
        public bool Estado { get; set; }
    }
}
