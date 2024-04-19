using BLL;
using BLL_EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kolokwiumRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentBLL_EF _studentBLL;

        public StudentsController(StudentBLL_EF studentBLL)
        {
            _studentBLL = studentBLL;
        }

        [HttpGet]
        public ActionResult<List<StudentDTO>> GetAllStudents()
        {
            return _studentBLL.GetAllStudents();
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDTO> GetStudentById(int id)
        {
            var student = _studentBLL.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
        public IActionResult AddStudent(StudentDTO student)
        {
            _studentBLL.AddStudent(student);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, StudentDTO student)
        {
            if (id != student.ID)
            {
                return BadRequest();
            }

            _studentBLL.UpdateStudent(student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _studentBLL.DeleteStudent(id);
            return Ok();
        }
    }
}
