using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace PL__MVC.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        [HttpGet]
        public ActionResult GetAll()
        {
            Ml.Result result = Bl.Libro.GetAllEF();
            Ml.Libro libro = new Ml.Libro();
            if (result.Correct)
            {
                libro.Libros = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error, no se pueden mostar los registro ";
            }
            return View(libro);
        }
        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {
            Ml.Libro libro = new Ml.Libro();
            Ml.Result resulrol = new Ml.Result();
            libro.Autor = new Ml.Autor();
            libro.Editorial = new Ml.Editorial();
            libro.Genero = new Ml.Genero();

            Ml.Result resultautor = Bl.Autor.GetAllEF();
            Ml.Result resulteditorial = Bl.Editorial.GetAllEF();
            Ml.Result resultgenero = Bl.Genero.GetAllEF();

            if (IdLibro == null)
            {

                libro.Autor.Autores = resultautor.Objects;
                libro.Editorial.Editoriales = resulteditorial.Objects;
                libro.Genero.Generos= resultgenero.Objects;
                
                return View(libro);
            }

            else
            {
                Ml.Result result = Bl.Libro.GetByIdEF(IdLibro.Value);

                if (result.Correct)
                {
                    libro = (Ml.Libro)result.Object;
                    
                    libro.Autor.Autores = resultautor.Objects;
                    libro.Editorial.Editoriales = resulteditorial.Objects;
                    libro.Genero.Generos = resultgenero.Objects;


                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar al usuario seleccionado";
                }
                return View(libro);
            }
        }

        [HttpPost]
        public ActionResult Form(Ml.Libro libro)
        {

            if (libro.IdLibro == 0)
            {
                //add
                Ml.Result result = Bl.Libro.AddEF(libro);

                if (result.Correct)
                {
                    libro = (Ml.Libro)result.Object;
                    ViewBag.Mensaje = "Libro guardado exitosamente";

                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al agregar el libro";
                }
            }
            else
            {
                //update
                Ml.Result result = Bl.Libro.UpdateEF(libro);

                if (result.Correct)
                {
                    libro = (Ml.Libro)result.Object;
                    ViewBag.Mensaje = "libro Actualizado Correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error El libro no se pudo actualizar";
                }

            }

            return PartialView("Modal");

        }

        public ActionResult Delete(int IdLibro)
        {

            Ml.Result result = new Ml.Result();
            result = Bl.Libro.DeleteEF(IdLibro);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Se elimino el registro";
            }
            return PartialView("Modal");
        }
    }
}