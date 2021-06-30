using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       
        
        [HttpGet]
        [Route("/api/GetAll")]
        public IActionResult GetAll()
        {

            return Ok("hai there raj");

        }



    }
}
