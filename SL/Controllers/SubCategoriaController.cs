using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class SubCategoriaController : ApiController
    {
        // GET: api/SubCategoria

        [HttpGet]
        [Route("api/SubCategoria/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.SubCategoria.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
                         
        }

        /// GET: api/SubCategoria/5
        [HttpGet]
        [Route("api/SubCategoria/GetById/{IdSubCategoria}")]
        public IHttpActionResult GetById(int IdSubCategoria)
        {
            ML.Result result = BL.SubCategoria.GetById(IdSubCategoria);

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }


        [HttpPost]
        [Route("api/SubCategoria/Add")]
        // POST: api/SubCategoria
        public IHttpActionResult Post([FromBody]ML.SubCategoria subCategoria)
        {
            ML.Result result = BL.SubCategoria.AddEF(subCategoria);
            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPost]
        [Route("api/SubCategoria/Update")]
        // PUT: api/SubCategoria/5
        public IHttpActionResult Put([FromBody]ML.SubCategoria subCategoria)
        {
            var result = BL.SubCategoria.UpdateEF(subCategoria);

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }


        [HttpGet]
        [Route("api/SubCategoria/Delete/{IdSubCategoria}")]
        // GET: api/SubCategoria/Delete
        public IHttpActionResult Delete(int IdSubCategoria)
        {           
            ML.Result result = BL.SubCategoria.DeleteEF(IdSubCategoria);

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }
    }
}
