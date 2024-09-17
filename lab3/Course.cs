using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public List<int> Students { get; set; }

        public Course(int id, string name, int teacherId)
        {
            Id = id;
            Name = name;
            TeacherId = teacherId;
            Students = new List<int>();
        }

        public override string ToString()
        {
            return $"Course_Id = {Id}, Name = {Name}, Teacher_Id = {TeacherId}, Students_Id = {string.Join(",", Students)}";
        }
    }
}
