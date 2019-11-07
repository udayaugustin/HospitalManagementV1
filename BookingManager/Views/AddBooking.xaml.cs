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
            var bookingcost = TotalBookingCost.Text;
            var advanceAmount = AdvanceAmount.Text;
            var paymentMode = PaymentMode.Text;

            var booking = new Booking
            {
                Name = name,
                PhoneNo = phoneNo,
                CheckinDate = checkinDate,
                CheckoutDate = checkoutDate,
                BookingCost = bookingcost,
                AdvanceAmount = advanceAmount,
                
            };
            await connection.InsertAsync(booking);
            var mainPage = Application.Current.MainPage as MasterDetailPage;
            mainPage.Detail = new NavigationPage(new BookingList());
            
        }
    }
}
