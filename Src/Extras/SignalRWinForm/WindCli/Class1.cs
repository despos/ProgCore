using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindCli
{
    public class TimeInterval
    {
        public TimeInterval(DateTime? from = null, DateTime? to = null)
        {
            From = from ?? DateTime.MinValue;
            To = to ?? DateTime.MaxValue;
        }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class Booking
    {
        private readonly TimeInterval _timeInterval = new TimeInterval();

        public static class Factory
        {
            public static Booking New(int bookingId, int roomId, DateTime? from, DateTime? to)
            {
                return new Booking()
                {
                    BookingId = bookingId,
                    RoomId = roomId,
                    Interval = new TimeInterval(from, to)
                };
            }
        }

        public int BookingId { get; private set; }
        public int RoomId { get; private set; }
        public TimeInterval Interval { get; private set; }

        public override string ToString()
        {
            if (Interval == null)
                return "Empty";
            if (Interval.)
        }
    }
}
