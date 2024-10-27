using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techonology.Entities;
using Techonology.Repositories.Interfaces;

namespace Techonology.Repositories.Implementations
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext _context;
        public CityRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Edit(City city)
        {
            _context.Update<City>(city);
            _context.SaveChanges();
        }

        public IEnumerable<City> GetAll()
        {
           return _context.Cities.Include(x=>x.state).ThenInclude(y=>y.country).ToList();           
        }

        public City GetById(int id)
        {
            var city = _context.Cities.Find(id);
            return city;
        }

        public void RemoveData(City city)
        {
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }

        public void Save(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }

    }
}
