using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaTrack.Data;
using AquaTrack.Data.Models;

namespace AquaTrack.Repositories
{
    public class IoTDeviceRepository : IRepository<IoTDevice>
    {
        private readonly AppDbContext _context;

        public IoTDeviceRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<IoTDevice> GetAll()
        {
            return _context.IoTDevices.ToList();
        }

        public IoTDevice GetById(int id)
        {
            return _context.IoTDevices.Find(id);
        }

        public void Add(IoTDevice entity)
        {
            _context.IoTDevices.Add(entity);
            _context.SaveChanges();
        }

        public void Update(IoTDevice entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var device = _context.IoTDevices.Find(id);
            if (device != null)
            {
                _context.IoTDevices.Remove(device);
                _context.SaveChanges();
            }
        }
    }
}
