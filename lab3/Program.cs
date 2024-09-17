using lab3;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        var studentFactory = new StudentFactory();
        var teacherFactory = new TeacherFactory();
        var courseFactory = new CourseFactory();

        var database = new Database();

        var student1 = (Student)studentFactory.CreatePerson(1, "John Doe");
        var student2 = (Student)studentFactory.CreatePerson(2, "Jane Smith");

        var teacher1 = (Teacher)teacherFactory.CreatePerson(1, "Mr. Johnson", 10);

        var course1 = courseFactory.CreateCourse(1, "Mathematics", teacher1.Id);
        course1.Students.Add(student1.Id);
        course1.Students.Add(student2.Id);

        teacher1.Courses.Add(course1.Id);
        student1.Courses.Add(course1.Id);
        student2.Courses.Add(course1.Id);

        database.AddStudent(student1);
        database.AddStudent(student2);
        database.AddTeacher(teacher1);
        database.AddCourse(course1);

        database.SaveToFile("C:\\Users\\1\\source\\repos\\lab3\\lab3\\database.txt");

        var loadedDatabase = new Database();
        loadedDatabase.LoadFromFile("C:\\Users\\1\\source\\repos\\lab3\\lab3\\database.txt");

        Console.WriteLine("Данные загружены:");
        loadedDatabase.SaveToFile(Console.Out);
    }
}