using EcommerceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalougeController : ControllerBase
    {
        private readonly MyContext _myContext;

        public CatalougeController(MyContext context)
        {

            _myContext = context;
           // _myContext.Database.EnsureCreated();
        }


        [HttpGet]
        [Route("authors")]
        public IActionResult GetAllAuthors()
        {
          
            return Ok(_myContext.Authors.ToArray());
          
        }

        [HttpGet]
        [Route("authors/{Id:int}")]
        public async Task<IActionResult> GetAuthor(int Id)
        {
            var Author = await _myContext.Authors.FindAsync(Id);

            if (Author == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Author);
            }



        }


        public IActionResult GetStudentData()
        {
            List<Book> books = new List<Book>();

            ResponseModel _objResponseModel = new ResponseModel();
            List<Student> students = new List<Student>();
            students.Add(new Student
            {
                ID = 101,
                Name = "Seam",
                Email = "seam@gmail.com",
                Address = "Dhaka,Bangladesh"
            });
            students.Add(new Student
            {
                ID = 102,
                Name = "Mitila",
                Email = "mitila@gmail.com",
                Address = "Dhaka,Bangladesh"
            });
            students.Add(new Student
            {
                ID = 104,
                Name = "Popy",
                Email = "popy@yahoo.com",
                Address = "Dhaka,Bangladesh"
            });

            _objResponseModel.Data = students;
            _objResponseModel.Status = true;
            _objResponseModel.Message = "Data Received successfully";
            _objResponseModel.Students = students;


            return Ok(_objResponseModel);

        }

        

        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
        }


        public class ResponseModel
        {
            public string Message { set; get; }
            public bool Status { set; get; }
            public object Data { set; get; }

            public List<Student> Students { get; set; }

          
        }


        


    }
}
