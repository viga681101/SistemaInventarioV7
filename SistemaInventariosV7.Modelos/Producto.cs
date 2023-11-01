﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventariosV7.Modelos
{
    public  class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Numero de serie es requerido")]
        [MaxLength(60)]
        public string NumeroSerie { get; set; }
        [Required(ErrorMessage = "Descripción es requerido")]
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Precio es requerido")]

        public double Precio { get; set; }
        [Required(ErrorMessage = "Costo es requerido")]
        public double Costo { get; set; }
        public string ImagenUrl { get; set; }
        [Required(ErrorMessage = "Estado es requerido")]
        public bool Estado {  get; set; }
        [Required(ErrorMessage = "Categoria es requerido")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set;}
        [Required(ErrorMessage = "Marca es requerido")]
        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public Marca Marca { get; set;}

        public int? PadreId { get; set; }
        public virtual Producto Padre { get; set; }



    }
}
