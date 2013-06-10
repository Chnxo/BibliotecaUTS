using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Dominio;

namespace Datos
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("BibliotecaUTS")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Editorial> Editoriales { get; set; }

        public DbSet<Libro> Libros { get; set; }
    }
}