using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Techonology.Entities;
using Techonology.Repositories.Interfaces;

namespace Techonology.UI.Controllers
{
    public class StateController : Controller
    {
        private readonly IStateRepo _stateRepo;
        private readonly ICountryRepo _countryRepo;

        public StateController(IStateRepo stateRepo, ICountryRepo countryRepo)
        {
            _stateRepo = stateRepo;
            _countryRepo = countryRepo;
        }

        public IActionResult Index()
        {
            var state= _stateRepo.GetAll();
            return View(state);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var countries= _countryRepo.GetAll();
            ViewBag.CountryList =new SelectList(countries,"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(State state)
        {
            _stateRepo.Save(state);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)            
        {
            var state = _stateRepo.GetById(id);
            var countries=_countryRepo.GetAll();
            ViewBag.CountryList=new SelectList(countries,"Id","Name");
            return View(state);
        }
        [HttpPost]
        public IActionResult Edit(State state)
        {
            _stateRepo.Edit(state);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var state = _stateRepo.GetById(id);
            _stateRepo.RemoveData(state);
            return RedirectToAction("Index");
        }
    }
}
