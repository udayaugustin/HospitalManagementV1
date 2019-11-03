using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace BookingManager.Views
{
    public partial class AddBooking : ContentPage
    {
        SQLiteAsyncConnection connection;
        public AddBooking()
        {
            InitializeComponent();

            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        private void Add(object sender, EventArgs e)
        {
            var name = Name.Text;
            var phoneNo = PhoneNo.Text;
            var checkinDate = CheckInDate.Text;
            var checkoutDate = CheckOutDate.Text;
            var totalBookingCost = TotalBookingCost.Text;
            var advanceAmount = AdvanceAmount.Text;
            var paymentMode = PaymentMode.Text;

            var booking = new Booking
            {
                Name = name,
                PhoneNo = phoneNo,
                CheckinDate = checkinDate,
                CheckoutDate = checkoutDate,
            }
        }
    }
}
