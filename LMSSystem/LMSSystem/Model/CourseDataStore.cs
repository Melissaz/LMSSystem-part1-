using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LMSSystem.Model
{
    public class CourseDataStore : ICourseDataStore
    {
        private CourseDBContext _ctx;

        public CourseDataStore(CourseDBContext ctx)
        {
            _ctx = ctx;
        }

        IEnumerable<CourseDto> ICourseDataStore.GetAllCourses()
        {
            return _ctx.Courses
                        .Include(a => a.StudentCheckIns)
                        .ThenInclude(b => b.Student)
                        .ToList();
        }

        public CourseDto GetCourseByID(int courseID)
        {
            return _ctx.Courses.Find(courseID);
        }

        public void AddCourse(CourseDto course)
        {
            _ctx.Courses.Add(course);
            Save();
        }

        public CourseDto UpdateCourse(int courseID, CourseDto course)
        {
            CourseDto oddCourse = _ctx.Courses.Find(courseID);
            oddCourse.Name = course.Name;
            oddCourse.Description = course.Description;
            Save();
            return _ctx.Courses.Find(courseID);
        }

        bool ICourseDataStore.DeleteCourse(int courseID)
        {
            CourseDto oddCourse = _ctx.Courses.Find(courseID);
            if (oddCourse != null)
            {
                _ctx.Courses.Remove(oddCourse);
            }
            return Save();
        }

        public bool Save()
        {
            return (_ctx.SaveChanges() >= 0);
        }

        IEnumerable<Student> ICourseDataStore.GetAllStudents()
        {
            return _ctx.Students.ToList();
        }

        public void AddStudent(Student student)
        {
            _ctx.Students.Add(student);
            Save(); 
        }

        bool ICourseDataStore.DeleteStudent(string studentName)
        {
            Student oddStudent = _ctx.Students.Find(studentName);
            if (oddStudent != null)
            {
                _ctx.Students.Remove(oddStudent);
            }
            return Save();
        }

        Student ICourseDataStore.GetStudentByName(string studentName)
        {
            return _ctx.Students.Find(studentName);
        }

        Student ICourseDataStore.UpdateStudent(string studentName, Student student)
        {
            Student oddStudent = _ctx.Students.Find(studentName);
            oddStudent.Id = student.Id;
            oddStudent.GPA = student.GPA;
            oddStudent.CourseLimit = student.CourseLimit;
            Save();
            return _ctx.Students.Find(studentName);
        }

        public void AddCheckIn(int courseID, int studentID)
        {
            CourseDto course = _ctx.Courses.Find(courseID);
            Student student = _ctx.Students.Find(studentID);

            var newCheckIn = new StudentCheckIn { CourseId = courseID, StudentId = studentID };
            _ctx.StudentCheckIns.Add(newCheckIn);
            Save();
        }
        public void RemoveCheckIn(int courseID, int studentID)
        {
            var checkIn = _ctx.StudentCheckIns.Find(courseID, studentID);
            if (checkIn != null)
            {
                _ctx.StudentCheckIns.Remove(checkIn);
            }
            Save();
        }



    }
}
