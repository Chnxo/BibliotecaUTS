using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Dominio
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [DisplayName("Usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [DisplayName("Contraseña")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Correo")]
        public string Correo { get; set; }
    }
}