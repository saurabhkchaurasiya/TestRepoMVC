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
    public class StateRepo:IStateRepo
    {
        private readonly ApplicationDbContext _context;
        public StateRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Edit(State state)
        {
            _context.Update<State>(state);
            _context.SaveChanges();
        }

        public IEnumerable<State> GetAll()
        {
            var state = _context.States.Include(x=>x.country).ToList();
            return state;
        }

        public State GetById(int id)
        {
            var state = _context.States.Find(id);
            return state;
        }

        public void RemoveData(State state)
        {
            _context.States.Remove(state);
            _context.SaveChanges();
        }

        public void Save(State state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
        }
    }
}
