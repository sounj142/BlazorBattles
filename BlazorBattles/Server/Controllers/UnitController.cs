using Microsoft.AspNetCore.Mvc;

namespace BlazorBattles.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitController : ControllerBase
    {
        public UnitController()
        {
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("");
        }
    }
}
