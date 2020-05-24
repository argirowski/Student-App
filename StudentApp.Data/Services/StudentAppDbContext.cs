using StudentApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Data.Services
{
    public class StudentAppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
