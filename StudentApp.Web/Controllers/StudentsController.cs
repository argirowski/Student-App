using StudentApp.Data.Models;
using StudentApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestorauntApp.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentData db;

        public StudentsController(StudentData db)
        {
            this.db = db;
        }
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            } else
            {
                return View(model);
            }
        }
        //GET Method
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //POST Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            //if(String.IsNullOrEmpty(student.Name))
            //{
            //    ModelState.AddModelError(nameof(student.Name), "The Name Of the Student Is Required");
            //}
            if (ModelState.IsValid)
            {
                db.Add(student);
                return RedirectToAction("Details", new { id = student.Id });
            }
            return View();
        }
        //GET Method
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            } else
            {
                return View(model);
            }
        }   
        //POST Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if(ModelState.IsValid)
            {
                db.Update(student);
                TempData["Message"] = "You have successfully saved your data.";
                return RedirectToAction("Details", new { id = student.Id });                
            } else
            {
                return View();
            }
        }
        //GET Method
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(model);
            }
        }
        //POST Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}