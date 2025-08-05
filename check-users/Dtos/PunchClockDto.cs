using check_users.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace check_users.Dtos
{
    public class PunchClockDto
    {
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
        public DateTime CheckInTime { get; set; }
        public GeoLocation CheckInLocation { get; set; }

        public DateTime? CheckOutTime { get; set; }
        public GeoLocation? CheckOutLocation { get; set; }

        public bool Status { get; set; }
    }
}
