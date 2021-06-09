using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class CategoriaController : ApiController
    {
        [HttpGet]
        [Route("api/categoria/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Categoria.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
                         
        }

        // GET api/categoria/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/categoria
        public void Post([FromBody]string value)
        {
        }

        // PUT api/categoria/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/categoria/5
        public void Delete(int id)
        {
        }
    }
}
