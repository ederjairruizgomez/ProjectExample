using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Categoria
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EcommerceAlexEntities context = new DL.EcommerceAlexEntities())
                {

                    var query = (from a in context.Categorias
                                 select a).ToList();

                    result.Objects = new List<object>();

                    if (query.ToList().Count >= 1)
                    {
                        foreach (var obj in query)
                        {
                            ML.Categoria categoria = new ML.Categoria();

                            categoria.IdCategoria = obj.IdCategoria;
                            categoria.Descripcion = obj.Descripcion;                            

                            result.Objects.Add(categoria);
                        }

                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros en la tabla SubCategoria";
                    }

                }

            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }


            return result;
        }
    }
}
