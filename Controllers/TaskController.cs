using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskDB.MVC.Models;

namespace TaskDB.MVC.Controllers
{
    public class TaskController : Controller
    {
        private Context _db;

        public TaskController(Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var model = _db.Tasks.ToList();
            return View(model);
        }
        public IActionResult Create()
        {

            return View();
        }
        public IActionResult Update(Guid id){
            var model = _db.Tasks.Where(x=>x.id == id).FirstOrDefault();
            return View(model);
        }

        public IActionResult Delete(Guid id){
            var model = _db.Tasks.Where(x=>x.id == id).FirstOrDefault();
            _db.Tasks.Remove(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

         public IActionResult UpdateTask(TaskModel model){
            _db.Tasks.Update(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddTask(TaskModel model){
            _db.Tasks.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }       
    }
}
