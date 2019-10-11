using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Nutrition.Api.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet] 
        public string Get()
        {
            return "OK";
        }
    }
}
