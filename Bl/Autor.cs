using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class Autor
    {
        public static Ml.Result GetAllEF()
        {
            Ml.Result result = new Ml.Result();
            try
            {
                using (DL.ZjuanLibrosEntities1 contex = new DL.ZjuanLibrosEntities1())
                {
                    var autores = contex.AutorGetAll().ToList();
                    result.Objects = new List<object>();
                    if (autores != null)
                    {
                        foreach (var obj in autores)
                        {

                            Ml.Autor autor = new Ml.Autor();

                            autor.IdAutor = obj.IdAutor;
                            autor.Nombre = obj.Nombre;

                            result.Objects.Add(autor);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "los Paises no se puden mostar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }
    }
}
