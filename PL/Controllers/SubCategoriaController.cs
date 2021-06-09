using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class SubCategoriaController : Controller
    {
        // GET: SubCategoria
        public ActionResult GetAll()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            ML.Result result = BL.SubCategoria.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(ML.SubCategoria subcategoria)
        {
            ML.Result result = BL.SubCategoria.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update()
        {
            ML.Result result = BL.SubCategoria.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }  
 
 
 
        [HttpGet]
        public ActionResult Form()
        {           
            return View(new ML.SubCategoria());
        }


    }
}