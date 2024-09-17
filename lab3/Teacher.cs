using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public List<int> Courses { get; set; }

        public Teacher(int id, string name, int experience)
        {
            Id = id;
            Name = name;
            Experience = experience;
            Courses = new List<int>();
        }

        public override string ToString()
        {
            return $"Teacher_Id = {Id}, Name = {Name}, Exp = {Experience}, Courses = {string.Join(",", Courses)}";
        }
    }
}
