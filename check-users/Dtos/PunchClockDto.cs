using check_users.Models;

namespace check_users.Dtos
{
    public class PunchClockDto
    {
        public DateTime CheckInTime { get; set; }
        public GeoLocation CheckInLocation { get; set; }

        public DateTime? CheckOutTime { get; set; }
        public GeoLocation? CheckOutLocation { get; set; }

        public bool Status { get; set; }
    }
}
