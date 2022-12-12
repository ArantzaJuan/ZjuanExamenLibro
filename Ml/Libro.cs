using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ml
{
     public class Libro
    {
         public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public int NumeroDePaginas { get; set; }
        public string FechaPublicacion { get; set; }
        public string Edicion { get; set; }
        public Ml.Autor Autor { get; set; }
        public Ml.Editorial Editorial { get; set; }
        public Ml.Genero Genero { get; set; }
        public List<object> Libros { get; set; }
    }
}
