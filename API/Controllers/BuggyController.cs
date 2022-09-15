using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController: BaseApiController
    {
        [HttpGet("NotFound")]
        public ActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet("BadRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ProblemDetails{Title= "This is a bad request"});
        }

        [HttpGet("Unauthorized")]
        public ActionResult GetUnauthorized()
        {
            return Unauthorized();
        }

        [HttpGet("ValidationError")]
        public ActionResult GetValidationError()
        {
            ModelState.AddModelError("Problem 1", "This is the first error");
            ModelState.AddModelError("Problem 2", "This is the seconde error");

            return ValidationProblem();
        }

        [HttpGet("ServerError")]
        public ActionResult GetServerError()
        {
            throw new Exception("This is a server error");
        }
    }
}