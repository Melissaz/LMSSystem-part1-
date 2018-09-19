using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LMSSystem.Model;

namespace LMSSystem.Controllers
{
    [Route("api/student")]

    public class StudentController : Controller
    {
        private ICourseDataStore _dataStore;

        public StudentController(ICourseDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        // GET api/values

        [HttpGet]
        public IActionResult Get()
        {
            var result = _dataStore.GetAllStudents();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var studentResult = _dataStore.GetStudentByName(name);
            IActionResult result;
            if (studentResult == null)
            {
                result = NotFound();
            }
            else
            {
                result = Ok(studentResult);
            }
            return result;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Student value)
        {
            _dataStore.AddStudent(value);
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{Name}")]
        public IActionResult Put(string name, [FromBody] Student value)
        {
            Student resultStudent = _dataStore.UpdateStudent(name, value);
            IActionResult result;
            if (resultStudent != null)
            {
                result = Accepted(resultStudent);
            }
            else
            {
                result = NotFound();
            }
            return result;
        }

        // DELETE api/values/5
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            IActionResult result;
            bool isRecordExist = _dataStore.DeleteStudent(name);
            if (isRecordExist)
            {
                result = NoContent();
            }
            else
            {
                result = NotFound();
            }
            return result;
        }
    }
}
