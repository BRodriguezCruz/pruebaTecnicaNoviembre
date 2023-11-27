using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Celular
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PruebaTecnicaNoviembreContext context = new DL.PruebaTecnicaNoviembreContext())
                {
                    var query = context.Celulars.FromSqlRaw($"CelularGetAll").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Celular celular = new ML.Celular();

                            celular.IdCelular = registro.IdCelular;
                            celular.Modelo = registro.Modelo;
                            celular.Precio = registro.Precio;
                            celular.FechaLanzamiento = registro.FechaLanzamiento;

                            celular.Marca = new ML.Marca();
                            celular.Marca.IdMarca = registro.IdMarca;
                            celular.Marca.Nombre = registro.NombreMarca;

                            result.Objects.Add(celular);
                        }
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
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int idCelular)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PruebaTecnicaNoviembreContext context = new DL.PruebaTecnicaNoviembreContext())
                {
                    var query = context.Celulars.FromSqlRaw($"CelularGetById {idCelular}").AsEnumerable().SingleOrDefault();

                    if (query != null)
                    {

                        ML.Celular celular = new ML.Celular();

                        celular.IdCelular = query.IdCelular;
                        celular.Modelo = query.Modelo;
                        celular.Precio = query.Precio;
                        celular.FechaLanzamiento = query.FechaLanzamiento;

                        celular.Marca = new ML.Marca();
                        celular.Marca.IdMarca = query.IdMarca;
                        celular.Marca.Nombre = query.NombreMarca;

                        result.Object = celular;
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
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Add(ML.Celular celular)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PruebaTecnicaNoviembreContext context = new DL.PruebaTecnicaNoviembreContext())
                {
                    var fecha = celular.FechaLanzamiento.Value.ToString("dd-MM-yyyy");

                    var query = context.Database.ExecuteSqlRaw($"CelularAdd '{celular.Modelo}', {celular.Precio}, '{fecha}', {celular.Marca.IdMarca}");

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
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Celular celular)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PruebaTecnicaNoviembreContext context = new DL.PruebaTecnicaNoviembreContext())
                {

                    var fecha = celular.FechaLanzamiento.Value.ToString("dd-MM-yyyy");

                    var query = context.Database.ExecuteSqlRaw($"CelularUpdate {celular.IdCelular},'{celular.Modelo}', {celular.Precio}, '{fecha}', {celular.Marca.IdMarca}");

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
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int idCelular)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PruebaTecnicaNoviembreContext context = new DL.PruebaTecnicaNoviembreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"CelularDelete {idCelular}");

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
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }
    }
}