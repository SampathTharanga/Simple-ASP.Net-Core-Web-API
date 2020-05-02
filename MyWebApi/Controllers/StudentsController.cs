using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        List<Student> _oStudents = new List<Student>()
        {
            new Student(){ Id = 1, Name = "Sampath", Rolle = 1001 },
            new Student(){ Id = 2, Name = "Tharanga", Rolle = 1002 },
            new Student(){ Id = 3, Name = "Sajith", Rolle = 1003 },
            new Student(){ Id = 4, Name = "Roshan", Rolle = 1004 },
            new Student(){ Id = 5, Name = "Githanjana", Rolle = 1005 },
            new Student(){ Id = 6, Name = "Anuranga", Rolle = 1006 },
            new Student(){ Id = 7, Name = "Vimukthi", Rolle = 1007 }
        };

        //SELECT ALL STUDENT
        [HttpGet]
        public IActionResult Gets()
        {
            if (_oStudents.Count == 0)
                return NotFound("No list found");
            return Ok(_oStudents);
        }

        //SELECT SPECIFIC STUDENT
        [HttpGet("GetStudent")]
        public IActionResult Get(int id)
        {
            var oStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if (oStudent == null)
                return NotFound("No student found");
            return Ok(oStudent);
        }

        //INSERT STUDENT
        [HttpPost]
        public IActionResult Save(Student oStudent)
        {
            _oStudents.Add(oStudent);
            if (_oStudents.Count == 0)
                return NotFound("No list found");
            return Ok(_oStudents);
        }

        //DELETE STUDENT
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var oStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if (oStudent == null)
                return NotFound("No student found");
            _oStudents.Remove(oStudent);

            if (_oStudents.Count == 0)
                return NotFound("No list found.");
            return Ok(_oStudents);
        }
    }
}