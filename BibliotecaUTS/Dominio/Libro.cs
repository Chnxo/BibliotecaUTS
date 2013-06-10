using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    [Table("Libros")]
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int NumeroPaginas { get; set; }

        public string Descripcion { get; set; }

        public virtual Editorial Editorial { get; set; }

        public virtual Autor Autor { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}