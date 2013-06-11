using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Autores")]
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        [Required]
        public string Nombre { get; set; }

        public virtual IList<Libro> Libros { get; set; }
    }
}