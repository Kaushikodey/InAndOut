using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    [Authorize]
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ExpenseType> objlist = _db.ExpenseType;
            return View(objlist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType item)
        {
            _db.ExpenseType.Add(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int Id)
        {
            _db.ExpenseType.Remove(_db.ExpenseType.Find(Id));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? Id)
        {
            if(Id==null ||Id==0)
            {
                return NotFound();
            }
            var obj = _db.ExpenseType.Find(Id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType Obj)
        {
            _db.ExpenseType.Update(Obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
