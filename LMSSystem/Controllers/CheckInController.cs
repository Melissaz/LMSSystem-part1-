using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LMSSystem.Model;


namespace LMSSystem.Controllers
{
    [Route("api/CheckIn")]
    public class CheckInController : Controller
    {

        private ICourseDataStore _dataStore;

        public CheckInController(ICourseDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        [HttpPost]
        public void Post([FromBody] StudentInCourseDTO checkIn)
        {
            _dataStore.AddCheckIn(checkIn.CourseId, checkIn.StudentId);
        }


        [HttpDelete("{id}")]
        public void Delete([FromBody] StudentInCourseDTO checkIn)
        {
            _dataStore.RemoveCheckIn(checkIn.CourseId, checkIn.StudentId);
        }
    }
}
