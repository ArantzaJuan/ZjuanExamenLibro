using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pl
{
    class Program
    {
        static void Main(string[] args)
        {
            int opc;
            Console.WriteLine("********************************");
            Console.WriteLine(" \t  Menú libro        ");
            Console.WriteLine("********************************");

            Console.WriteLine("**  1)   Mostrar libros          **");
            Console.WriteLine("**  2)   Mostrar solo un libro   **");
            Console.WriteLine("**  3)   Ingresar un libro       **");
            Console.WriteLine("**  4)   Actualizar un libro     **");
            Console.WriteLine("**  5)   Eliminar un libro       **");
            
            Console.WriteLine("********************************");
            Console.WriteLine("\n Ingrese el numero de la accion que desea realizar ");

            opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("*************************************");
                    Console.WriteLine("**          Mostrar libro          **");
                    Console.WriteLine("*************************************\n");
                     
                    Pl.Libro.GetAll();

                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("*************************************");
                    Console.WriteLine("**     Mostrar solo un libro       **");
                    Console.WriteLine("************************************* \n");
                    //Se mando llamar a la clase de PL porque es en donde se insertan los datos 
                    Pl.Libro.GetById();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("*************************************");
                    Console.WriteLine("**     Ingresar un libro       **");
                    Console.WriteLine("*************************************\n");
                    //Se mando llamar a la clase de PL porque es en donde se insertan los datos 
                    Pl.Libro.Add();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("*************************************");
                    Console.WriteLine("**      Actualizar un libro        **");
                    Console.WriteLine("*************************************\n");
                    //Se mando llamar a la clase de PL porque es en donde se insertan los datos 
                    Pl.Libro.UpDate();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("*************************************");
                    Console.WriteLine("**     Eliminar un libro     **");
                    Console.WriteLine("*************************************\n");
                    //Se mando llamar a la clase de PL porque es en donde se insertan los datos
                    Pl.Libro.Delete();
                    break;
            }
        }
    }
}
