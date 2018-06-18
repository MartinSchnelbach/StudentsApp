using System;
using System.Collections.Generic;
using StudentsCRUDApp.Models.Students;

namespace StudentsCRUDApp.Services
{
    public interface StudentsInterface
    {
        List<Student> GetStudents();
        Student GetStudent(int id);
        void AddStudent(Student item);
        void UpdateStudent(Student item);
        void DeleteStudent(int id);
        bool StudentExists(int id);
    }
}
