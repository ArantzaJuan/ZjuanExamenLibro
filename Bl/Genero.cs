using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class Genero
    {
        public static Ml.Result GetAllEF()
        {
            Ml.Result result = new Ml.Result();
            try
            {
                using (DL.ZjuanLibrosEntities1 contex = new DL.ZjuanLibrosEntities1())
                {
                    var generos = contex.GeneroGetAll().ToList();
                    result.Objects = new List<object>();
                    if (generos != null)
                    {
                        foreach (var obj in generos)
                        {

                            Ml.Genero genero = new Ml.Genero();

                            genero.IdGenero = obj.IdGenero;
                            genero.Nombre = obj.Nombre;

                            result.Objects.Add(genero);
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
