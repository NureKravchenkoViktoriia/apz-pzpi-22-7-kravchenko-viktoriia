using AquaTrack.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Data.Models
{
    public class CreateLimitRequest
    {
        [Column("limit_value")]
        public decimal LimitValue { get; set; }   // Максимальне значення споживання води
        [Column("start_date")]
        public DateTime StartDate { get; set; }  // Дата початку дії ліміту
        [Column("end_date")]
        public DateTime EndDate { get; set; }    // Дата закінчення дії ліміту
        [Column("user_id")]
        public int UserId { get; set; }          // Ідентифікатор користувача
        [Column("device_id")]
        public int DeviceId { get; set; }        // Ідентифікатор IoT-пристрою
    }

}
