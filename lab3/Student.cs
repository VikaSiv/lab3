using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Courses { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
            Courses = new List<int>();
        }

        public override string ToString()
        {
            return $"Student_Id = {Id}, Name = {Name}, Courses = {string.Join(",", Courses)}";
        }
    }
}
