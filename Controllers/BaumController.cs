using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BaumController : ControllerBase    
    {
        [HttpPost("/create")]
        public async Task<ActionResult<int>> CreateBaum(CreateBaumDto newBaum)
        {
            var baumId = 11;
            return Ok(baumId);
        }
       

    }
}
