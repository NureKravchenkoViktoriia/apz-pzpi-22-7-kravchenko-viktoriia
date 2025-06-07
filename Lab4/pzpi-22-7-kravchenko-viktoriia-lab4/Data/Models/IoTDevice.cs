using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Data.Models
{
    public class IoTDevice
    {
        [Key]
        [Column("device_id")]
        public int DeviceId { get; set; }
        [Column("device_type")]
        public string DeviceType { get; set; }
        [Column("status")]
        public string Status { get; set; }

        // Зв’язок із таблицею Limits
        public ICollection<Limit> Limits { get; set; }
    }
}