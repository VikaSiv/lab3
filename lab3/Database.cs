using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Database
    {
        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();
        private List<Course> courses = new List<Course>();

        public void AddStudent(Student student) => students.Add(student);
        public void AddTeacher(Teacher teacher) => teachers.Add(teacher);
        public void AddCourse(Course course) => courses.Add(course);

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var student in students)
                    writer.WriteLine(student);

                foreach (var teacher in teachers)
                    writer.WriteLine(teacher);

                foreach (var course in courses)
                    writer.WriteLine(course);
            }
        }

        public void LoadFromFile(string filename)
        {
            students.Clear();
            teachers.Clear();
            courses.Clear();

            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ", " }, StringSplitOptions.None);
                if (parts[0].StartsWith("Student_Id"))
                {
                    var id = int.Parse(parts[0].Split(" = ")[1]);
                    var name = parts[1].Split(" = ")[1];
                    var courses = parts[2].Split(" = ")[1].Split(',').Select(int.Parse).ToList();

                    var student = new Student(id, name) { Courses = courses };
                    students.Add(student);
                }
                else if (parts[0].StartsWith("Teacher_Id"))
                {
                    var id = int.Parse(parts[0].Split(" = ")[1]);
                    var name = parts[1].Split(" = ")[1];
                    var experience = int.Parse(parts[2].Split(" = ")[1]);
                    var courses = parts[3].Split(" = ")[1].Split(',').Select(int.Parse).ToList();

                    var teacher = new Teacher(id, name, experience) { Courses = courses };
                    teachers.Add(teacher);
                }
                else if (parts[0].StartsWith("Course_Id"))
                {
                    var id = int.Parse(parts[0].Split(" = ")[1]);
                    var name = parts[1].Split(" = ")[1];
                    var teacherId = int.Parse(parts[2].Split(" = ")[1]);
                    var students = parts[3].Split(" = ")[1].Split(',').Select(int.Parse).ToList();

                    var course = new Course(id, name, teacherId) { Students = students };
                    courses.Add(course);
                }
            }
        }


        internal void SaveToFile(TextWriter @out)
        {
            foreach (var student in students)
            {
                @out.WriteLine(student);
            }

            foreach (var teacher in teachers)
            {
                @out.WriteLine(teacher);
            }

            foreach (var course in courses)
            {
                @out.WriteLine(course);
            }
        }

    }
}
