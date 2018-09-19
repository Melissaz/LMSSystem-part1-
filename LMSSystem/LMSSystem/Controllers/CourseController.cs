using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LMSSystem.Model;

namespace LMSSystem.Controllers
{
    [Route("api/course")]

    public class CourseController : Controller
    {
        private ICourseDataStore _dataStore;

        public CourseController(ICourseDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _dataStore.GetAllCourses();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var courseResult = _dataStore.GetCourseByID(id);
            IActionResult result;
            if (courseResult == null)
            {
                result = NotFound();
            }
            else
            {
                result = Ok(courseResult);
            }
            return result;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CourseDto value)
        {
            _dataStore.AddCourse(value);
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CourseDto value)
        {
            CourseDto resultCourse = _dataStore.UpdateCourse(id, value);
            IActionResult result;
            if(resultCourse != null)
            {
                result = Accepted(resultCourse);
            }
            else
            {
                result = NotFound();
            }
            return result;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult result;
            bool isRecordExist = _dataStore.DeleteCourse(id);
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
