﻿using System;
namespace BookingManager
{
    public class Booking
    {
        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public DateTime CheckinDate { get; set; }

        public DateTime CheckoutDate { get; set; }

        public int BookingCost { get; set; }

        public int AdvanceAmount { get; set; }

        public string PaymentMode { get; set; }
    }
}
