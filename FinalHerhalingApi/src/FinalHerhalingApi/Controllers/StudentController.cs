using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalHerhalingApi.repositories;
using ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalHerhalingApi.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private SchoolRepository repo;

        public StudentController(SchoolRepository schoolRepo)
        {
            repo = schoolRepo;
        }

        // GET: api/values
        [HttpGet]
        public ICollection<StudentBasic> Get()
        {
            return repo.getAllStudenten();
        }

        // GET api/values/5
        [HttpGet("{id}",Name ="StudentGet")]
        public StudentBasic Get(int id)
        {
            return repo.getStudentById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]StudentBasic student)
        {
            try
            {
                if (student !=null)
                {
                    repo.addStudent(student);
                    return Created(Url.Link("StudentGet", new { id = student.StudId }), student);
                    
                }
                return BadRequest("Student is null");
            }
            catch (Exception)
            {

                return BadRequest("Error could not add student");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
