using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Data.Models
{
    public class WaterUsageRequest
    {
        [Column("usage_value")]
        public decimal UsageValue { get; set; }
        [Column("device_id")]
        public int DeviceId { get; set; }
        [Column("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
