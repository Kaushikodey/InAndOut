using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    [Authorize]
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objlist = _db.Expense;
            return View(objlist);
        }
       
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseType.Select(x => new SelectListItem
            {
                Text=x.Name,
                Value=x.Id.ToString()
            });
            ViewBag.TypeDropDown = TypeDropDown;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense item)
        {
            _db.Expense.Add(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int Id)
        {
            _db.Expense.Remove(_db.Expense.Find(Id));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? Id)
        {
            if(Id==null ||Id==0)
            {
                return NotFound();
            }
            var obj = _db.Expense.Find(Id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense Obj)
        {
            _db.Expense.Update(Obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
