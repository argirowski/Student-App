using StudentApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp.Data.Services
{
    public class InMemoryStudentData : StudentData
    {   
        List<Student> students;
        public InMemoryStudentData()
        {
            students = new List<Student>()
            {
                new Student {Id = 1, Name = "George", CourseType = CourseType.Poetry},
                new Student {Id = 2, Name = "Natasha", CourseType = CourseType.Accounting},
                new Student {Id = 3, Name = "Lena", CourseType = CourseType.Journalism}

            };
        }
        public void Add(Student student)
        {
            students.Add(student);
            student.Id = students.Max(r => r.Id) + 1;

        }
        public void Update(Student student)
        {
            var existingStudent = Get(student.Id);
            if(existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.CourseType = student.CourseType;
            }

        }
        public Student Get(int id)
        {
            return students.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return students.OrderBy(r => r.Name);
        }

        public void Delete(int id)
        {
            var student = Get(id);
            if(student != null)
            {
                students.Remove(student);
            }
        }
    }
}
