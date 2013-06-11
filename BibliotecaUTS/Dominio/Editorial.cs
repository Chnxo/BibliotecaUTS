using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Dominio
{
    [Table("Editoriales")]
    public class Editorial
    {
        [Key]
        public int IdEditorial { get; set; }

        [Required]
        public string Nombre { get; set; }

        public virtual IList<Libro> Libros { get; set; }
    }
}