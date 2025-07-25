using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SIMPLECRUD.Model;
using SIMPLECRUD.Services;

namespace SIMPLECRUD.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IStudentInterface Student { get; set; }

        public StudentController(IStudentInterface student)
        {
            Student = student;
        }

        [HttpPost]
        [Route("api/Create")]
        public async Task<IActionResult> Create(Student student)
        {
            var students = await Student.CreateAsync(student);
            return students > 0 ? Ok("Student added successfully.") :
            BadRequest("Insert failed.");        
        }
    }
}
