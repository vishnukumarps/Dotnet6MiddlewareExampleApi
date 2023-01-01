using Dotnet6MiddlewareExampleApi.CustomAttributes;
using Dotnet6MiddlewareExampleApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dotnet6MiddlewareExampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [MyCustomAttribute2]
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            return Ok(student);
        }
        
    }
}
