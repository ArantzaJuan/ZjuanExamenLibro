using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class Libro
    {
        public static Ml.Result Add(Ml.Libro libro)
        {
            Ml.Result result = new Ml.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "LibroAdd";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = context;

                        SqlParameter[] colletion = new SqlParameter[7];
                        colletion[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        colletion[0].Value = libro.Nombre;
                        colletion[1] = new SqlParameter("@NumeroDePaginas", System.Data.SqlDbType.Int);
                        colletion[1].Value = libro.NumeroDePaginas;
                        colletion[2] = new SqlParameter("@FechaPublicacion", System.Data.SqlDbType.VarChar);
                        colletion[2].Value = libro.FechaPublicacion;
                        colletion[3] = new SqlParameter("@Edicion", System.Data.SqlDbType.VarChar);
                        colletion[3].Value = libro.Edicion;
                        colletion[4] = new SqlParameter("@IdAutor", System.Data.SqlDbType.Int);
                        colletion[4].Value = libro.Autor.IdAutor;
                        colletion[5] = new SqlParameter("@IdEditorial", System.Data.SqlDbType.Int);
                        colletion[5].Value = libro.Editorial.IdEditorial;
                        colletion[6] = new SqlParameter("@IdGenero", System.Data.SqlDbType.Int);
                        colletion[6].Value = libro.Genero.IdGenero;
                        command.Parameters.AddRange(colletion);

                        command.Connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                        }
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
        public static Ml.Result GetAll()
        {
            Ml.Result result = new Ml.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroGetAll";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = contex;


                        DataTable tablelibro = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablelibro);
                        if (tablelibro.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tablelibro.Rows)
                            {
                                Ml.Libro libro = new Ml.Libro();
                                libro.Autor = new Ml.Autor();
                                libro.Editorial = new Ml.Editorial();
                                libro.Genero = new Ml.Genero();

                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.Nombre = row[1].ToString();
                                libro.NumeroDePaginas = int.Parse(row[2].ToString());
                                libro.FechaPublicacion = row[3].ToString();
                                libro.Edicion = row[4].ToString();

                                
                                libro.Autor.IdAutor = int.Parse(row[5].ToString());
                                libro.Autor.Nombre = row[6].ToString();

                                
                                libro.Editorial.IdEditorial = int.Parse(row[7].ToString());
                                libro.Editorial.Nombre = row[8].ToString();

                                
                                libro.Genero.IdGenero = int.Parse(row[9].ToString());
                                libro.Genero.Nombre = row[10].ToString();

                                result.Objects.Add(libro);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

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
        public static Ml.Result GetById(int IdLibro)
        {
            Ml.Result result = new Ml.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroGetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdLibro", SqlDbType.Int);
                        collection[0].Value = IdLibro;
                        cmd.Parameters.AddRange(collection);
                        //Almacena la informacion 
                        DataTable tablelibro = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        // 
                        adapter.Fill(tablelibro);

                        if (tablelibro.Rows.Count > 0)
                        {   //instancia de clase DataRow(este es la fila de datos)
                            DataRow row = tablelibro.Rows[0];

                            Ml.Libro libro = new Ml.Libro();
                            libro.Autor = new Ml.Autor();
                            libro.Editorial = new Ml.Editorial();
                            libro.Genero = new Ml.Genero();

                            libro.Nombre = row[0].ToString();
                            libro.NumeroDePaginas = int.Parse(row[1].ToString());
                            libro.FechaPublicacion = row[2].ToString();
                            libro.Edicion = row[3].ToString();


                            libro.Autor.IdAutor = int.Parse(row[4].ToString());
                            libro.Autor.Nombre = row[5].ToString();


                            libro.Editorial.IdEditorial = int.Parse(row[6].ToString());
                            libro.Editorial.Nombre = row[7].ToString();


                            libro.Genero.IdGenero = int.Parse(row[8].ToString());
                            libro.Genero.Nombre = row[9].ToString();


                            result.Object = libro;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

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
        public static Ml.Result Update(Ml.Libro libro)
        {
            Ml.Result result = new Ml.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "LibroUpDate";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = context;

                        SqlParameter[] colletion = new SqlParameter[8];

                        colletion[0] = new SqlParameter("@IdLibro", System.Data.SqlDbType.Int);
                        colletion[0].Value = libro.IdLibro;

                        colletion[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        colletion[1].Value = libro.Nombre;
                        colletion[2] = new SqlParameter("@NumeroDePaginas", System.Data.SqlDbType.Int);
                        colletion[2].Value = libro.NumeroDePaginas;
                        colletion[3] = new SqlParameter("@FechaPublicacion", System.Data.SqlDbType.VarChar);
                        colletion[3].Value = libro.FechaPublicacion;
                        colletion[4] = new SqlParameter("@Edicion", System.Data.SqlDbType.VarChar);
                        colletion[4].Value = libro.Edicion;
                        colletion[5] = new SqlParameter("@IdAutor", System.Data.SqlDbType.Int);
                        colletion[5].Value = libro.Autor.IdAutor;
                        colletion[6] = new SqlParameter("@IdEditorial", System.Data.SqlDbType.Int);
                        colletion[6].Value = libro.Editorial.IdEditorial;
                        colletion[7] = new SqlParameter("@IdGenero", System.Data.SqlDbType.Int);
                        colletion[7].Value = libro.Genero.IdGenero;
                        command.Parameters.AddRange(colletion);

                        command.Connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                        }
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
        public static Ml.Result Delete(Ml.Libro libro)
        {
            Ml.Result result = new Ml.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "LibroDetele";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = context;

                        SqlParameter[] colletion = new SqlParameter[1];

                        colletion[0] = new SqlParameter("@IdLibro", System.Data.SqlDbType.Int);
                        colletion[0].Value = libro.IdLibro;

                        
                        command.Parameters.AddRange(colletion);

                        command.Connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                        }
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



        // Métodos para MVC en Entity framework 



        public static Ml.Result AddEF(Ml.Libro libro)
        {
            Ml.Result result = new Ml.Result();
            try
            {
                using (DL.ZjuanLibrosEntities1 contex = new DL.ZjuanLibrosEntities1())
                {
                    var query = contex.LibroAdd(libro.Nombre,libro.NumeroDePaginas, libro.FechaPublicacion,libro.Edicion,libro.Autor.IdAutor, libro.Editorial.IdEditorial,libro.Genero.IdGenero);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ingreso el registro";
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
        public static Ml.Result GetAllEF()
        {
            Ml.Result result = new Ml.Result();
            try
            {
                using (DL.ZjuanLibrosEntities1 contex = new DL.ZjuanLibrosEntities1())
                {
                    var libros = contex.LibroGetAll().ToList();
                    result.Objects = new List<object>(); 
                    if (libros != null)
                    {
                        foreach (var obj in libros)
                        {

                            Ml.Libro libro = new Ml.Libro();

                            libro.Autor = new Ml.Autor();
                            libro.Editorial = new Ml.Editorial();
                            libro.Genero = new Ml.Genero();

                            libro.IdLibro = obj.IdLibro;
                            libro.Nombre = obj.Nombre;
                            libro.NumeroDePaginas = obj.NumeroDePaginas.Value;
                            libro.FechaPublicacion = obj.FechaPublicacion.Value.ToString("dd-MM-yyyy");
                            libro.Edicion = obj.Edicion;

                            libro.Autor.IdAutor = obj.IdAutor;
                            libro.Autor.Nombre = obj.Nombre;

                            libro.Editorial.IdEditorial = obj.IdEditorial;
                            libro.Editorial.Nombre = obj.Nombre;

                            libro.Genero.IdGenero = obj.IdGenero;
                            libro.Genero.Nombre = obj.Nombre;

                            result.Objects.Add(libro);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ingreso el registro";
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
        public static Ml.Result GetByIdEF(int IdLibro)
        {
            Ml.Result result = new Ml.Result();
            try
            {
                using (DL.ZjuanLibrosEntities1 contex = new DL.ZjuanLibrosEntities1())
                {
                    var libros = contex.LibroGetById(IdLibro).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (libros != null)
                    {
                        
                            Ml.Libro libro = new Ml.Libro();

                        
                            libro.Autor = new Ml.Autor();
                            libro.Editorial = new Ml.Editorial();
                            libro.Genero = new Ml.Genero();

                     
                            libro.Nombre = libros.Nombre;
                            libro.NumeroDePaginas = libros.NumeroDePaginas.Value;
                            libro.FechaPublicacion = libros.FechaPublicacion.Value.ToString("dd-MM-yyyy");
                            libro.Edicion = libros.Edicion;

                            libro.Autor.IdAutor = libros.IdAutor;
                            libro.Autor.Nombre = libros.Nombre;

                            libro.Editorial.IdEditorial = libros.IdEditorial;
                            libro.Editorial.Nombre = libros.Nombre;

                            libro.Genero.IdGenero = libros.IdGenero;
                            libro.Genero.Nombre = libros.Nombre;

                            result.Object=libro;
                        
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ingreso el registro";
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
        public static Ml.Result UpdateEF(Ml.Libro libro)
        {
            Ml.Result result = new Ml.Result();
            try
            {
                using (DL.ZjuanLibrosEntities1 contex = new DL.ZjuanLibrosEntities1())
                {
                    var query = contex.LibroUpDate(libro.Nombre, libro.NumeroDePaginas, libro.FechaPublicacion, libro.Edicion, libro.Autor.IdAutor, libro.Editorial.IdEditorial, libro.Genero.IdGenero,libro.IdLibro);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ingreso el registro";
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
        public static Ml.Result DeleteEF(int IdLibro)
        {
            Ml.Result result = new Ml.Result();
            try
            {
                using (DL.ZjuanLibrosEntities1 context = new DL.ZjuanLibrosEntities1())
                {
                    var query = context.LibroDetele(IdLibro);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = !false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }
    }
}
