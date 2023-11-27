using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Marca
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PruebaTecnicaNoviembreContext context = new DL.PruebaTecnicaNoviembreContext())
                {
                    var query = context.Celulars.FromSqlRaw($"MarcaGetAll").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Marca marca = new ML.Marca();    

                            marca.IdMarca = registro.IdMarca;
                            marca.Nombre = registro.NombreMarca;

                            result.Objects.Add(marca);
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
    }
}
