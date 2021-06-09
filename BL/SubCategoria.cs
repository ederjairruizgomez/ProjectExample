using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubCategoria
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EcommerceAlexEntities context = new DL.EcommerceAlexEntities())
                {

                    var query = (from a in context.SubCategorias
                                 select a).ToList();

                    result.Objects = new List<object>();

                    if (query.ToList().Count >= 1)
                    {
                        foreach (var obj in query)
                        {
                            ML.SubCategoria subCategoria = new ML.SubCategoria();

                            subCategoria.IdSubCategoria = obj.IdSubCategoria;
                            subCategoria.Nombre = obj.Nombre;
                            subCategoria.Descripcion = obj.Descripcion;
                            subCategoria.Categoria = new ML.Categoria();
                            subCategoria.Categoria.IdCategoria = obj.IdCategoria.Value;
                            result.Objects.Add(subCategoria);
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
        public static ML.Result AddEF(ML.SubCategoria subCategoria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EcommerceAlexEntities context = new DL.EcommerceAlexEntities())
                {


                    DL.SubCategoria subCategoriaDL = new DL.SubCategoria();
                    //{
                    //         Nombre=subCategoria.Nombre,
                    //         Descripcion=subCategoria.Descripcion,
                    //         IdCategoria=subCategoria.Categoria.IdCategoria
                    //};
                    subCategoriaDL.Nombre = subCategoria.Nombre;
                    subCategoriaDL.Descripcion = subCategoria.Descripcion;
                    subCategoriaDL.IdCategoria = 1;


                    context.SubCategorias.Add(subCategoriaDL);
                    int i = context.SaveChanges();

                    if (i >= 1)
                    {
                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto";
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
        public static ML.Result UpdateEF(ML.SubCategoria subCategoria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EcommerceAlexEntities context = new DL.EcommerceAlexEntities())
                {
                    var query = (from s in context.SubCategorias
                                 where s.IdSubCategoria == subCategoria.IdSubCategoria
                                 select s).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = subCategoria.Nombre;
                        query.Descripcion = subCategoria.Descripcion;
                        query.IdCategoria = 1;

                        context.SaveChanges();
                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro la SubCategoria";
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
        public static ML.Result DeleteEF(int id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EcommerceAlexEntities context = new DL.EcommerceAlexEntities())
                {
                    var query = (from subcategoria in context.SubCategorias
                                 where subcategoria.IdSubCategoria == id
                                 select subcategoria).First();

                    context.SubCategorias.Remove(query);
                    context.SaveChanges();

                    if (query != null)
                    {
                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al intentar eliminar el registro";
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
        public static ML.Result GetById(int id)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EcommerceAlexEntities context = new DL.EcommerceAlexEntities())
                {
                    var obj = context.SubCategoriaGetById(id).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                       
                            ML.SubCategoria subCategoriaItem = new ML.SubCategoria();

                            subCategoriaItem.IdSubCategoria = obj.IdSubCategoria;
                            subCategoriaItem.Nombre = obj.Nombre;
                            subCategoriaItem.Descripcion = obj.Descripcion;

                            subCategoriaItem.Categoria = new ML.Categoria();
                            subCategoriaItem.Categoria.IdCategoria = obj.IdCategoria.Value;

                            result.Object =subCategoriaItem;
                            result.Correct = true;
                     

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la entidad seleccionada";
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
