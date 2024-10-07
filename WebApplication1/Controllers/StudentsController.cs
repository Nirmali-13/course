using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entity;
using WebApplication1.iRepository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IstudentRepository _studentRepository;

        public StudentsController(IstudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpPost("Add-Student")]
        public IActionResult AddStudent(Students student)
        {
            var studentobject = new Students();
            studentobject.Id = student.Id;
            studentobject.Name = student.Name;
            studentobject.Email = student.Email;
            _studentRepository.AddStudent(studentobject);
            return Ok(studentobject);
        }
    }
}
