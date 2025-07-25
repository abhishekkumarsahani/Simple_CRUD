using Microsoft.AspNetCore.Mvc;
using SIMPLECRUD.Model;
using SIMPLECRUD.Services;

namespace SIMPLECRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentInterface _studentService;

        public StudentController(IStudentInterface studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            var result = await _studentService.CreateAsync(student);
            return result > 0 ? Ok("Student added successfully.") : BadRequest("Insert failed.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            return student == null ? NotFound("Student not found.") : Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {
            var result = await _studentService.UpdateAsync(student);
            return result > 0 ? Ok("Student updated successfully.") : BadRequest("Update failed.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.DeleteAsync(id);
            return result > 0 ? Ok("Student deleted successfully.") : NotFound("Student not found.");
        }
    }
}
