using Microsoft.AspNetCore.Mvc;
using Techonology.Entities;
using Techonology.Repositories.Implementations;
using Techonology.Repositories.Interfaces;
using Techonology.UI.View_Models.CountryViewModel;

namespace Techonology.UI.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepo _countryRepo;

        public CountryController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }
        public IActionResult Index()
        {
            List<CountryViewModel> VM = new List<CountryViewModel>();                     
            var countries = _countryRepo.GetAll();
            foreach (var cotry in countries)
            {
                VM.Add(new CountryViewModel { Id = cotry.Id, Name = cotry.Name });
            }
                return View(VM);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            CreateCountryViewModel country = new CreateCountryViewModel();
            return View(country);
        }
        [HttpPost]
        public IActionResult Create(CreateCountryViewModel vm)
        {
            var cotry = new Country
            {
                Name =  vm.Name,
            };
            _countryRepo.Save(cotry);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var country= _countryRepo.GetById(id);
            CountryViewModel vm = new CountryViewModel
            {
                Id= country.Id,
                Name = country.Name,
            };
            return View(country);
        }
        [HttpPost]
        public IActionResult Edit(CountryViewModel vm)
        {
            var cotry = new Country
            {
                Id = vm.Id,
                Name = vm.Name,
            };
            _countryRepo.Edit(cotry); 
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var country = _countryRepo.GetById(id);
            _countryRepo.RemoveData(country);
            return RedirectToAction("Index");
        }
    }
}
