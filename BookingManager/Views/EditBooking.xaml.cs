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
	public partial class EditBooking : ContentPage
	{
        SQLiteAsyncConnection connection;
        List<Booking> bookingList;
        Booking _selectedbooking;

        public EditBooking (Booking booking)
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
            CheckInDate.Date = booking.CheckinDate;
            CheckOutDate.Date = booking.CheckoutDate;
            TotalBookingCost.Text = Convert.ToString(booking.BookingCost);
            AdvanceAmount.Text = Convert.ToString(booking.AdvanceAmount);
            PaymentMode.Text = booking.PaymentMode;
        }
        private async void Update(object sender, EventArgs e)
        {
            _selectedbooking.Name = Name.Text;
            _selectedbooking.PhoneNo = PhoneNo.Text;
            _selectedbooking.CheckinDate = CheckInDate.Date;
            _selectedbooking.CheckoutDate = CheckOutDate.Date;
            _selectedbooking.BookingCost = Convert.ToInt32(TotalBookingCost.Text);
            _selectedbooking.AdvanceAmount = Convert.ToInt32(AdvanceAmount.Text);
            _selectedbooking.PaymentMode = PaymentMode.Text;
            await connection.UpdateAsync(_selectedbooking);
            var mainPage = Application.Current.MainPage as MasterDetailPage;
            mainPage.Detail = new NavigationPage(new BookingList());
        }
    }
}