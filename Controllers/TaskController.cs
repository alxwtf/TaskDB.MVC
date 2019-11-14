using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskDB.MVC.Models;

namespace TaskDB.MVC.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private Context _db;

        private readonly UserManager<User> _userManager;
        public TaskController(Context db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.Tasks
                .Where(x => x.userid == _userManager.GetUserId(User))
                .ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskModel model)
        {
            _db.Tasks.Add(new TaskModel
            {
                Name = model.Name,
                Description = model.Description,
                Tag = model.Tag,
                CreationDate = model.CreationDate,
                Date = model.Date,
                userid = _userManager.GetUserId(User)
            });
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            var model = _db.Tasks.Where(x => x.id == id && x.userid == _userManager.GetUserId(User)).FirstOrDefault();
            if (model == null) return RedirectToAction("Index");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(TaskModel model)
        {
            model.userid = _userManager.GetUserId(User);
            _db.Tasks.Update(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var model = _db.Tasks.Where(x => x.id == id && x.userid == _userManager.GetUserId(User)).FirstOrDefault();
            _db.Tasks.Remove(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
