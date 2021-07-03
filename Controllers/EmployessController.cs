using EmployeeApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployessController : ControllerBase
    {

        private readonly EmployeeDbContext _context;
        private readonly IWebHostEnvironment _hostEnviroment;

        public EmployessController(EmployeeDbContext context, IWebHostEnvironment hostEnviroment)
        {

            _context = context;
            this._hostEnviroment = hostEnviroment;
        }


        // GET: api/<EmployessController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmployessController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployessController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> PostEmploymentModel([FromForm] EmployeeModel employeeModel)
        {
            var Image = await SaveImage(employeeModel.ImageFile);
            employeeModel.ImageName = Image;
            _context.Employess.Add(employeeModel);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }



        // PUT api/<EmployessController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployessController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string ImageName = new String(Path.GetFileName(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');

            ImageName = ImageName + DateTime.Now.ToString("MM/dd/yyyy") + Path.GetFileName(imageFile.FileName);

            var imagePath = Path.Combine(_hostEnviroment.ContentRootPath, "Images", ImageName);

            using (var FileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(FileStream);
            }

            return ImageName;
        }
    }
}