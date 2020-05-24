using StudentApp.Data.Models;
using StudentApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentApp.Web.Api
{
    public class StudentController : ApiController
    {
        private readonly StudentData db;
        public StudentController(StudentData db)
        {
            this.db = db;
        }
        public IEnumerable<Student> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
