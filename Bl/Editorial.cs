using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class Editorial
    {
        public static Ml.Result GetAllEF()
        {
            Ml.Result result = new Ml.Result();
            try
            {
                using (DL.ZjuanLibrosEntities1 contex = new DL.ZjuanLibrosEntities1())
                {
                    var editoriales = contex.EditorialGetAll().ToList();
                    result.Objects = new List<object>();
                    if (editoriales != null)
                    {
                        foreach (var obj in editoriales)
                        {

                            Ml.Editorial editorial = new Ml.Editorial();

                            editorial.IdEditorial = obj.IdEditorial;
                            editorial.Nombre = obj.Nombre;

                            result.Objects.Add(editorial);
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
