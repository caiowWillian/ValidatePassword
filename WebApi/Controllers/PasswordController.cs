using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Model;
using System;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly ILogger<PasswordController> _logger;

        public PasswordController(ILogger<PasswordController> logger)
        {
        }

        [HttpPost]
        public IActionResult SendPassword(UserPassword userPassword)
        {
            Console.WriteLine("hahaha");
            if(userPassword.IsValid()) return Ok();

            return BadRequest();
        }
    }
}