using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsWebAPI.Business.RepositoryLogic;
using StudentsWebAPI.Data;
using StudentsWebAPI.Data.Models;

namespace StudentsWebAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<StudentModel> GetStudents()
        {
            return _studentService.GetStudents();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentModel = await _studentService.GetStudent(id);

            if (studentModel == null)
            {
                return NotFound();
            }

            return Ok(studentModel);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent([FromRoute] Guid id, [FromBody] StudentModel studentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentModel.Id)
            {
                return BadRequest();
            }

            bool updated = await _studentService.UpdateStudent(studentModel);

            if(updated)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
            
        }

        // POST: api/Students
        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] StudentModel studentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool added = await _studentService.AddStudent(studentModel);

            if(added)
            {
                return CreatedAtAction("GetStudent", new { id = studentModel.Id }, studentModel);
            }
            else
            {
                return BadRequest();
            }
          
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentModel = await _studentService.GetStudent(id);
            if (studentModel == null)
            {
                return NotFound();
            }

            bool deleted = await _studentService.DeleteStudent(id);

            if(deleted)
            {
                return Ok(studentModel);
            }
            else
            {
                return NotFound();
            }
 
        }

    }
}