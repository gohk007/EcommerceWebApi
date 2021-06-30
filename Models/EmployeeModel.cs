using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName ="nvarchar(50)") ]
        public string EmployeeName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Ocupation { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ImageName { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
