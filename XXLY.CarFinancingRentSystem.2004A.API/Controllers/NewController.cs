using Microsoft.AspNetCore.Mvc;
namespace XXLY.CarFinancingRentSystem._2004A.API.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]

    public class NewController : ControllerBase
    {
        [HttpGet]
        public IActionResult jwtToken()
        {
            return Ok(JWTService.GetNewJWT());
        }

        [HttpGet]
        public IActionResult aaa(int a = 1, int b = 1)
        {
            var c = a + b;

            return Ok(c);
        }
    }
}
