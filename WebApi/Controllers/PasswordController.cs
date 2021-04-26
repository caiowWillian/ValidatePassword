using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Model;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly ILogger<PasswordController> _logger;

        public PasswordController(ILogger<PasswordController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SendPassword(UserPassword userPassword)
        {
            if(userPassword.IsValid()) return Ok();

            return Unauthorized();
        }
    }
}