using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookingDetail : ContentPage
	{
        SQLiteAsyncConnection connection;
        List<Booking> bookingList;
        Booking _selectedbooking;
        public BookingDetail (Booking booking)
		{
			InitializeComponent ();
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _selectedbooking = booking;
            GetData(booking);
        }

        private async void GetData(Booking booking)
        {
            Name.Text = booking.Name;
            PhoneNo.Text = booking.PhoneNo;
            CheckInDate.Text = Convert.ToString(booking.CheckinDate.ToString("MMM-dd-yy (dddd)"));
            CheckOutDate.Text = Convert.ToString(booking.CheckoutDate.ToString("MMM-dd-yy (dddd)"));
            TotalBookingCost.Text = Convert.ToString(booking.BookingCost);
            AdvanceAmount.Text = Convert.ToString(booking.AdvanceAmount);
            PaymentMode.Text = booking.PaymentMode;
        }
	}
}