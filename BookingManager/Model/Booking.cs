using SQLite;
using System;
namespace BookingManager
{
    public class Booking
    {
        [AutoIncrement][PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public DateTime CheckinDate { get; set; }

        public DateTime CheckoutDate { get; set; }

        public string BookingCost { get; set; }

        public string AdvanceAmount { get; set; }

        public string PaymentMode { get; set; }
    }
}
