using StudentApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Data.Services
{
    public class SqlStudentData : StudentData
    {
        private readonly StudentAppDbContext db;

        public SqlStudentData(StudentAppDbContext db)
        {
            this.db = db;
        }
        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
        }

        public Student Get(int id)
        {
            return db.Students.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return db.Students;
        }

        public void Update(Student student)
        {
            //Not the best way
            //var r = Get(restaurant.Id);
            //r.Name = "";

            //Optimistic concurrency
            var entry = db.Entry(student);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
