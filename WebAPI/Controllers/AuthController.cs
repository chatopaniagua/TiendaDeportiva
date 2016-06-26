using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {

        [Route("")]
        [HttpGet]
        public IHttpActionResult hello()
        {
            List<Persons> people = new List<Persons> {
                new Persons() { Name = "Chato", Age = 23 },
                new Persons() { Name = "Fer", Age = 27 },
                new Persons() { Name = "Crispin", Age = 25 },
                new Persons() { Name = "Bicho", Age = 24 },
                new Persons() { Name = "Mama", Age = 53 },
                new Persons() { Name = "Yuri", Age = 24 }
            };
            return Ok(people);
        }

        [HttpGet]
        [Route("notfound")]
        public IHttpActionResult lookForSomethingNonExistent()
        {
            return NotFound();
        }

    }
}
