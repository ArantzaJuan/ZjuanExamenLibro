using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pl
{
    public class Libro
    {
        public static void Add()
        {
            Ml.Libro libro = new Ml.Libro();

            Console.WriteLine("Inserte el nombre del libro");
            libro.Nombre = Console.ReadLine();

            Console.WriteLine("Inserte el numero de paginas");
            libro.NumeroDePaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserte La fecha de publicidad ");
            libro.FechaPublicacion = Console.ReadLine();

            Console.WriteLine("Inserte la edicion");
            libro.Edicion = Console.ReadLine();

            libro.Autor = new Ml.Autor();
            Console.WriteLine("Inserte el id del autor");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            libro.Editorial = new Ml.Editorial();
            Console.WriteLine("Inserte el id de la editorial");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            libro.Genero = new Ml.Genero();
            Console.WriteLine("Inserte el id del genero");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            Ml.Result result = Bl.Libro.Add(libro);
            if (result.Correct == true)
            {
                Console.WriteLine("El libro se registro correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El libro no se registro" + result.ErrorMessage);
                Console.ReadKey();
            }
        }

        public static void GetAll()
        {
            Ml.Result result = Bl.Libro.GetAll();

            if (result.Correct == true)
            {
                foreach (Ml.Libro libro in result.Objects)
                {

                    Console.WriteLine("**********************"); 
                    Console.WriteLine("nombre del libro:" + libro.Nombre);
                    Console.WriteLine("n° de paginas:" + libro.NumeroDePaginas);
                    Console.WriteLine("Fecha de publicacion:" + libro.FechaPublicacion);
                    Console.WriteLine("Ediciono:" + libro.Edicion);
                    Console.WriteLine("Autor:" + libro.Autor.Nombre);
                    Console.WriteLine("Editorial:" + libro.Editorial.Nombre);
                    Console.WriteLine(" Genero:" + libro.Genero.Nombre);
                    Console.WriteLine("**********************");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("No se pudieron mostrar los libros" + result.ErrorMessage);
                Console.ReadKey();
            }
        }

        public static void GetById()

        {
            Console.WriteLine("Ingrese el Id del libro que desea consultar:");
            int IdLibro = int.Parse(Console.ReadLine());
            Ml.Result result = Bl.Libro.GetById(IdLibro);

            if (result.Correct == true)
            {
                Ml.Libro libro = new Ml.Libro();

                libro = (Ml.Libro)result.Object;
                    Console.WriteLine("**********************");
                    Console.WriteLine("nombre del libro:" + libro.Nombre);
                    Console.WriteLine("n° de paginas:" + libro.NumeroDePaginas);
                    Console.WriteLine("Fecha de publicacion:" + libro.FechaPublicacion);
                    Console.WriteLine("Ediciono:" + libro.Edicion);
                    Console.WriteLine("Autor:" + libro.Autor.Nombre);
                    Console.WriteLine("Editorial:" + libro.Editorial.Nombre);
                    Console.WriteLine(" Genero:" + libro.Genero.Nombre);
                    Console.WriteLine("**********************");
                    Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El libro no se pudo mostrar" + result.ErrorMessage);
                Console.ReadKey();
            }
        }

        public static void UpDate()
        {
            Ml.Libro libro = new Ml.Libro();
            int id;

            Console.WriteLine("Inserte el Id del libro que desea Actualizar");
            id = int.Parse(Console.ReadLine());
            libro.IdLibro = id;

            Console.WriteLine("Inserte el nombre del libro");
            libro.Nombre = Console.ReadLine();

            Console.WriteLine("Inserte el numero de paginas");
            libro.NumeroDePaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserte La fecha de publicidad ");
            libro.FechaPublicacion = Console.ReadLine();

            Console.WriteLine("Inserte la edicion");
            libro.Edicion = Console.ReadLine();

            libro.Autor = new Ml.Autor();
            Console.WriteLine("Inserte el id del autor");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            libro.Editorial = new Ml.Editorial();
            Console.WriteLine("Inserte el id de la editorial");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            libro.Genero = new Ml.Genero();
            Console.WriteLine("Inserte el id del genero");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            Ml.Result result = Bl.Libro.Update(libro);
            if (result.Correct == true)
            {
                Console.WriteLine("El libro se actualizo correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El libro no se actualizo " + result.ErrorMessage);
                Console.ReadKey();
            }
        }

        public static void Delete()
        {
            Ml.Libro libro = new Ml.Libro();
            int id;

            Console.WriteLine("Inserte el Id del libro que desea eliminar");
            id = int.Parse(Console.ReadLine());
            libro.IdLibro = id;

           

            Ml.Result result = Bl.Libro.Delete(libro);
            if (result.Correct == true)
            {
                Console.WriteLine("El libro se elimino correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El libro no se elimino" + result.ErrorMessage);
                Console.ReadKey();
            }
        }
    }
}
