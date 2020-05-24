using StudentApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestorauntApp.Web.Models
{
    public class GreetingViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
    }
}