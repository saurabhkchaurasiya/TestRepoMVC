using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Techonology.Entities;
using Techonology.Repositories.Interfaces;

namespace Techonology.UI.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepo _cityRepo;
        private readonly IStateRepo _stateRepo;

        public CityController(ICityRepo cityRepo, IStateRepo stateRepo)
        {
            _cityRepo = cityRepo;
            _stateRepo = stateRepo;
        }

        public IActionResult Index()
        {
            var city = _cityRepo.GetAll();
            return View(city);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var state= _stateRepo.GetAll();
            ViewBag.stateList = new SelectList(state, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(City city) 
        { 
            _cityRepo.Save(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var city = _cityRepo.GetById(id);
            var state = _stateRepo.GetAll();
            ViewBag.stateList = new SelectList(state, "Id", "Name"); 
            return View(city);
        }
        [HttpPost]
        public IActionResult Edit(City city)
        {
            _cityRepo.Edit(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var city= _cityRepo.GetById(id);
            _cityRepo.RemoveData(city);
            return RedirectToAction("Index");
        }
    }
}
