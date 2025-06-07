using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaTrack.Data;
using AquaTrack.Data.Models;

namespace AquaTrack.Repositories
{
    public class WaterUsageRepository : IRepository<WaterUsage>
    {
        private readonly AppDbContext _context;

        public WaterUsageRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<WaterUsage> GetAll()
        {
            return _context.WaterUsages.ToList();
        }

        public WaterUsage GetById(int id)
        {
            return _context.WaterUsages.Find(id);
        }

        public void Add(WaterUsage entity)
        {
            _context.WaterUsages.Add(entity);
            _context.SaveChanges();
        }

        public void Update(WaterUsage entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var usage = _context.WaterUsages.Find(id);
            if (usage != null)
            {
                _context.WaterUsages.Remove(usage);
                _context.SaveChanges();
            }
        }
    }
}
