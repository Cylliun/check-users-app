using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace check_users.Models
{
    public class PunchClock
    {
        [Key]
        public int Id { get; set; }

        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }

        public DateTime CheckInTime { get; set; }
        public GeoLocation CheckInlocation { get; set; }

        public DateTime? CheckOutTime { get; set; }
        public GeoLocation? CheckOutlocation {  get; set; }

        public bool Status { get; set; }

    }

}
