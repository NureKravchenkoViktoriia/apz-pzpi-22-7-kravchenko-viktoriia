using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Data.Models
{
    public class Limit
    {
        [Key]
        [Column("limit_id")]
        public int LimitId { get; set; }           // Унікальний ідентифікатор ліміту
        [Range(0.01, double.MaxValue, ErrorMessage = "Ліміт повинен бути більшим за 0.")]
        [Column("limit_value")]
        public decimal LimitValue { get; set; }   // Максимальне значення споживання води
        [Column("start_date")]
        public DateTime StartDate { get; set; }   // Дата початку дії ліміту
        [Column("end_date")]
        public DateTime EndDate { get; set; }     // Дата закінчення дії ліміту

        // Зовнішні ключі
        [Column("user_id")]
        public int UserId { get; set; }           // Зв'язок із користувачами
        public User User { get; set; }            // Навігаційна властивість
        
        [Column("device_id")]
        public int DeviceId { get; set; }         // Зв'язок із IoT-пристроями
        public IoTDevice IoTDevice { get; set; }  // Навігаційна властивість
    }
}