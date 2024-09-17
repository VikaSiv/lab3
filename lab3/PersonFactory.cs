using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public abstract class PersonFactory
    {
        public abstract object CreatePerson(int id, string name, int experienceOrCourses = 0);
    }
    public class StudentFactory : PersonFactory
    {
        public override object CreatePerson(int id, string name, int courses = 0)
        {
            return new Student(id, name);
        }
    }
    public class TeacherFactory : PersonFactory
    {
        public override object CreatePerson(int id, string name, int experience = 0)
        {
            return new Teacher(id, name, experience);
        }
    }
    public class CourseFactory
    {
        public Course CreateCourse(int id, string name, int teacherId)
        {
            return new Course(id, name, teacherId);
        }
    }
}
