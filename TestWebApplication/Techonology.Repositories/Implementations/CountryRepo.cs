using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techonology.Entities;
using Techonology.Repositories.Interfaces;

namespace Techonology.Repositories.Implementations
{
    public class CountryRepo:ICountryRepo
    {
        private readonly ApplicationDbContext _context;
        public CountryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Edit(Country country)
        {
            _context.Update<Country>(country);
            _context.SaveChanges();
        }

        public IEnumerable<Country> GetAll()
        {
           var countries = _context.Countries.ToList();
            return countries;
        }

        public Country GetById(int id)
        {
            var countries = _context.Countries.Find(id);
            return countries;
        }

        public void RemoveData(Country country)
        {
            _context.Countries.Remove(country);
            _context.SaveChanges();
        }

        public void Save(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }
    }
}
