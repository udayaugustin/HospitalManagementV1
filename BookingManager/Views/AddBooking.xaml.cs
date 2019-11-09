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

        private async void Add(object sender, EventArgs e)
        {
            var name = Name.Text;
            var phoneNo = PhoneNo.Text;
            var checkinDate = CheckInDate.Date;
            var checkoutDate = CheckOutDate.Date;
            var totalBookingCost = TotalBookingCost.Text;
            var bookingcost = Convert.ToInt32(TotalBookingCost.Text);
            var advanceAmount = Convert.ToInt32(AdvanceAmount.Text);
            var paymentMode = PaymentMode.Text;

            var booking = new Booking
            {
                Name = name,
                PhoneNo = phoneNo,
                CheckinDate = checkinDate.Date,
                CheckoutDate = checkoutDate.Date,
                BookingCost = Convert.ToInt32(bookingcost),
                AdvanceAmount = Convert.ToInt32(advanceAmount),
                PaymentMode = paymentMode,
                PaidAmount = Convert.ToInt32(advanceAmount),
                BalanceAmount = (bookingcost - advanceAmount),

            };
            await connection.InsertAsync(booking);
            var mainPage = Application.Current.MainPage as MasterDetailPage;
            mainPage.Detail = new NavigationPage(new BookingList());
            
        }
    }
}
