using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsCRUDApp.Models.Students;

namespace StudentsCRUDApp.Services
{
    public class StudentsService : StudentsInterface
    {
        private readonly List<Student> students;

        public StudentsService()
        {
            this.students = new List<Student>
            {
            new Student{ Id = 1, Name = "Jhon", Lastn = "Wick", Age = 12, Course = 3, Score = 4},
            new Student { Id = 2, Name = "Claire", Lastn = "Tommason", Age = 11, Course = 2, Score = 6 },
            new Student { Id = 3, Name = "Meredith", Lastn = "Grey", Age = 11, Course = 2, Score = 10 },
            new Student { Id = 4, Name = "Gregory", Lastn = "House", Age = 10, Course = 1, Score = 9 },
            new Student { Id = 5, Name = "Ned", Lastn = "Stark", Age = 15, Course = 5, Score = 2 }
            };
        }

        public List<Student> GetStudents()
        {
            return this.students.ToList();
        }

        public Student GetStudent(int id)
        {
            return this.students.Where(s => s.Id == id).FirstOrDefault();
        }

        public void AddStudent(Student item)
        {
            this.students.Add(item);
        }

        public void DeleteStudent(int id)
        {
            var model = this.students.Where(s => s.Id == id).FirstOrDefault();
        }

        public bool StudentExists(int id)
        {
            return this.students.Any(s => s.Id == id);
        }

        public void UpdateStudent(Student item)
        {
            var VarStudent = this.students.Where(s => s.Id == item.Id).FirstOrDefault();

            VarStudent.Name = item.Name;
            VarStudent.Lastn = item.Lastn;
            VarStudent.Age = item.Age;
            VarStudent.Course = item.Course;
            VarStudent.Age = item.Age;
        }

    }
}
