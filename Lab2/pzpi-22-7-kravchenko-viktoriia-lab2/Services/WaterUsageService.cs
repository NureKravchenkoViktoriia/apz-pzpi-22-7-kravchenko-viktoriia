using System;
using System.Collections.Generic;
using System.Linq;
using AquaTrack.Data.Models;
using AquaTrack.Repositories;

namespace AquaTrack.Services
{
    public class WaterUsageService
    {
        private readonly IRepository<WaterUsage> _repository;

        public WaterUsageService(IRepository<WaterUsage> repository)
        {
            _repository = repository;
        }

        public WaterUsage GetCurrentUsage(int deviceId)
        {
            return _repository
                .GetAll()
                .Where(w => w.DeviceId == deviceId)
                .OrderByDescending(w => w.Timestamp)
                .FirstOrDefault();
        }

        public IEnumerable<WaterUsage> GetUsageHistory(int? deviceId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _repository.GetAll().AsQueryable();

            if (deviceId.HasValue)
            {
                query = query.Where(w => w.DeviceId == deviceId.Value);
            }

            if (startDate.HasValue)
            {
                query = query.Where(w => w.Timestamp >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(w => w.Timestamp <= endDate.Value);
            }

            return query.OrderByDescending(w => w.Timestamp).ToList();
        }


        public void AddUsageRecord(WaterUsage usage, IoTDeviceService deviceService)
        {
            // Перевірка пристрою
            var device = deviceService.GetDeviceById(usage.DeviceId);
            if (device == null)
                throw new ArgumentException($"Device with ID {usage.DeviceId} not found.");

            // Перевірка дублювання запису
            var existingRecord = _repository.GetAll()
                .FirstOrDefault(w => w.DeviceId == usage.DeviceId && w.Timestamp == usage.Timestamp);

            if (existingRecord != null)
                throw new ArgumentException("Duplicate record for the same device and timestamp.");

            // Валідація обсягу
            if (usage.UsageValue < 0)
                throw new ArgumentException("Usage value cannot be negative.");

            // Додавання запису
            _repository.Add(usage);
        }

        public void DeleteUsageRecord(int id)
        {
            _repository.Delete(id);
        }

        public decimal GetAverageUsage(int deviceId, DateTime startDate, DateTime endDate)
        {
            var usageRecords = _repository
                .GetAll()
                .Where(w => w.DeviceId == deviceId && w.Timestamp >= startDate && w.Timestamp <= endDate)
                .ToList();

            if (!usageRecords.Any())
                throw new ArgumentException("No usage records found for the specified period.");

            // Підрахунок загального використання і середнього
            var totalUsage = usageRecords.Sum(w => w.UsageValue);
            var daysCount = (endDate - startDate).Days;

            return totalUsage / daysCount;
        }


    }
}
