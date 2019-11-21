using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CFAProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CFAProject.API.DTO;

namespace CFAProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CFAController : ControllerBase
    {
        private readonly ICFAService _service;

        public CFAController(ICFAService service)
        {
            _service = service;
        }

       

        [HttpPost]
        [Route("score")]
        public IActionResult Score([FromBody]Stream stream)
        {
            int score = 0;
            int result = _service.AddScore(stream.Input, score);
            if (result != -1)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("invalid input");
            }
        }

    }
}