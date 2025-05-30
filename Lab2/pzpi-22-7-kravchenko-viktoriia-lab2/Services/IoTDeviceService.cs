using System;
using System.Collections.Generic;
using AquaTrack.Data.Models;
using AquaTrack.Repositories;

namespace AquaTrack.Services
{
    public class IoTDeviceService
    {
        private readonly IRepository<IoTDevice> _repository;

        public IoTDeviceService(IRepository<IoTDevice> repository)
        {
            _repository = repository;
        }

        public IEnumerable<IoTDevice> GetAllDevices()
        {
            return _repository.GetAll();
        }

        public IoTDevice GetDeviceById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddDevice(IoTDevice device)
        {
            _repository.Add(device);
        }

        public void UpdateDevice(IoTDevice device)
        {
            _repository.Update(device);
        }

        public void DeleteDevice(int id)
        {
            _repository.Delete(id);
        }
    }
}
