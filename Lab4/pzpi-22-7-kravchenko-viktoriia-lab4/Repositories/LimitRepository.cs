using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaTrack.Data;
using AquaTrack.Data.Models;

namespace AquaTrack.Repositories
{
    public class LimitRepository : IRepository<Limit>
    {
        private readonly AppDbContext _context;

        public LimitRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Limit> GetAll()
        {
            return _context.Limits.ToList();
        }

        public Limit GetById(int id)
        {
            return _context.Limits.Find(id);
        }

        public void Add(Limit entity)
        {
            _context.Limits.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Limit entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var limit = _context.Limits.Find(id);
            if (limit != null)
            {
                _context.Limits.Remove(limit);
                _context.SaveChanges();
            }
        }
    }
}
