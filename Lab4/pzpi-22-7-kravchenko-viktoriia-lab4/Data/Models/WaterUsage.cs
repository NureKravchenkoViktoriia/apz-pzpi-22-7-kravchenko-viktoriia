using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Data.Models
{
    public class WaterUsage
    {
        [Key]
        [Column("usage_id")]
        public int UsageId { get; set; }         // Унікальний ідентифікатор запису
        [Column("usage_value")]
        public decimal UsageValue { get; set; } // Кількість спожитої води
        [Column("timestamp")]
        public DateTime Timestamp { get; set; } // Дата та час вимірювання

        // Зовнішній ключ
        [Column("device_id")]
        public int DeviceId { get; set; }       // Зв'язок із IoT-пристроями
        public IoTDevice IoTDevice { get; set; } // Навігаційна властивість
    }
}