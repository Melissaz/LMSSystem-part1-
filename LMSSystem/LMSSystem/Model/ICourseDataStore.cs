using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LMSSystem.Model
{
    public interface ICourseDataStore
    {
        //Course
        IEnumerable<CourseDto> GetAllCourses();
        CourseDto GetCourseByID(int courseID);
        void AddCourse(CourseDto course);
        CourseDto UpdateCourse(int courseID, CourseDto course);
        bool DeleteCourse(int courseID);
        bool Save();

        //Student
        IEnumerable<Student> GetAllStudents();
        Student GetStudentByName(string studentName);
        void AddStudent(Student student);
        Student UpdateStudent(string studentName, Student student);
        bool DeleteStudent(string studentName);

        //Student Check In
        void AddCheckIn(int courseID, int studentID);
        void RemoveCheckIn(int courseID, int studentID);

    }
}
