using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}