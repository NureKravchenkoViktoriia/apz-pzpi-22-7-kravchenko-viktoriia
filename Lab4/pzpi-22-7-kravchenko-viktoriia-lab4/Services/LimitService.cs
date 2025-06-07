using System.Collections.Generic;
using AquaTrack.Data.Models;
using AquaTrack.Repositories;
using System.Linq;
using AquaTrack.Data;
using System;

namespace AquaTrack.Services
{
    public class LimitService
    {
        private readonly IRepository<Limit> _repository;
        private readonly IRepository<WaterUsage> _waterUsageRepository;

        public LimitService(IRepository<Limit> repository, IRepository<WaterUsage> waterUsageRepository)
        {
            _repository = repository;
            _waterUsageRepository = waterUsageRepository;
        }

        public IEnumerable<Limit> GetAllLimits()
        {
            return _repository.GetAll();
        }

        public Limit GetLimitById(int id)
        {
            return _repository.GetById(id);
        }

        public void CreateLimit(Limit limit)
        {
            // Перевірка на наявність періодів, що перекриваються
            var existingLimit = _repository.GetAll().FirstOrDefault(l =>
                (l.UserId == limit.UserId || l.DeviceId == limit.DeviceId) &&
                (l.StartDate < limit.EndDate && l.EndDate > limit.StartDate));

            if (existingLimit != null)
            {
                throw new ArgumentException("Існує ліміт, який перекривається з цим.");
            }

            _repository.Add(limit);
        }


        public void UpdateLimit(Limit limit)
        {
            _repository.Update(limit);
        }

        public void DeleteLimit(int id)
        {
            var limit = _repository.GetById(id);
            if (limit == null) throw new ArgumentException("Ліміт не знайдено.");

            // Перевірка на наявність історії використання води
            var usageHistory = _waterUsageRepository.GetAll()
                .Where(w => w.DeviceId == limit.DeviceId &&
                            w.Timestamp >= limit.StartDate &&
                            w.Timestamp <= limit.EndDate)
                .Any();

            if (usageHistory)
            {
                throw new InvalidOperationException("Неможливо видалити ліміт, оскільки з ним пов'язана історія використання води.");
            }

            _repository.Delete(id);  // Видалення ліміту
        }


        public bool IsLimitExceeded(int limitId)
        {
            var limit = _repository.GetById(limitId);
            if (limit == null) throw new ArgumentException("Limit not found.");

            var totalUsage = _waterUsageRepository.GetAll()
                .Where(w => w.DeviceId == limit.DeviceId &&
                            w.Timestamp >= limit.StartDate &&
                            w.Timestamp <= limit.EndDate)
                .Sum(w => w.UsageValue);

            return totalUsage > limit.LimitValue;
        }

        public decimal GetLimitProgress(int limitId)
        {
            var limit = _repository.GetById(limitId);
            if (limit == null) throw new ArgumentException("Limit not found.");

            var totalUsage = _waterUsageRepository.GetAll()
                .Where(w => w.DeviceId == limit.DeviceId &&
                            w.Timestamp >= limit.StartDate &&
                            w.Timestamp <= limit.EndDate)
                .Sum(w => w.UsageValue);

            return (totalUsage / limit.LimitValue) * 100;
        }

    }
}
