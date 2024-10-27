using Microsoft.AspNetCore.Mvc;
using MVCWebApplication.Data;
using MVCWebApplication.Models;

namespace MVCWebApplication.Controllers
{
    public class PeopleController:Controller
    {
        private readonly ApplicationDbContext _context;
        public PeopleController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var peoples = _context.peoples.ToList();
            return View(peoples);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(People peoples)
        {
            _context.Add(peoples);
            _context .SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var people = _context.peoples.Find(id);
            return View(people);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var people = _context.peoples.Find(id);
            return View(people);
        }
        [HttpPost]
        public IActionResult Edit(People People)
        { 
           _context.Update(People);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var people = _context.peoples.Find(id);
            return View(people);
        }
        [HttpPost]
        public IActionResult Delete(People People)
        {
            _context.Remove(People);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
