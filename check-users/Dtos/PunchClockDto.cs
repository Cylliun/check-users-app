using check_users.Models;

namespace check_users.Dtos
{
    public class PunchClockDto
    {
        public DateTime CheckInTime { get; set; }
        public GeoLocation CheckInlocation { get; set; }

        public DateTime? CheckOutTime { get; set; }
        public GeoLocation? CheckOutlocation { get; set; }

        public bool Status { get; set; }
    }
}
