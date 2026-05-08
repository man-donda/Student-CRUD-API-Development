
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Data;
using StudentManagementApi.Models;

namespace StudentManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(dbContext.Students.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetStudentById(Guid id)
        {
            var student = dbContext.Students.Find(id);

            if (student is null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(CreateStudentDto createStudentDto)
        {
            var studentEntity = new Student()
            {
                Name = createStudentDto.Name,
                Email = createStudentDto.Email,
                City = createStudentDto.City
            };

            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();

            return Ok(studentEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateStudent(Guid id, UpdateStudentDto updateStudentDto)
        {
            var student = dbContext.Students.Find(id);

            if (student is null)
            {
                return NotFound();
            }
            student.Name = updateStudentDto.Name;
            student.Email = updateStudentDto.Email;
            student.City = updateStudentDto.City;

            dbContext.SaveChanges();

            return Ok(student);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteStudent(Guid id)
        {
            var student = dbContext.Students.Find(id);

            if (student is null)
            {
                return NotFound();
            }

            dbContext.Students.Remove(student);
            dbContext.SaveChanges();

            return Ok(student);
        }
    }
}