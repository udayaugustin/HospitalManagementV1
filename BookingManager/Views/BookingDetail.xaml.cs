using SQLite;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
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
            CheckInDate.Text = Convert.ToString(booking.CheckinDate.ToString("MMM-dd-yy (ddd)"));
            CheckOutDate.Text = Convert.ToString(booking.CheckoutDate.ToString("MMM-dd-yy (ddd)"));
            TotalBookingCost.Text = "Rs."+ Convert.ToString(booking.BookingCost);
            AdvanceAmount.Text = "Rs."+ Convert.ToString(booking.AdvanceAmount);
            PaymentMode.Text = booking.PaymentMode;
            BalanceAmount.Text = "Rs."+(_selectedbooking.BookingCost - _selectedbooking.PaidAmount).ToString();
        }

        private async void Update(object sender, EventArgs e)
        {           
            var Reminingcost = _selectedbooking.BookingCost - _selectedbooking.PaidAmount;
            if (RecivedAmount.Text != null)
            {
                var recivedcash = Convert.ToInt32(RecivedAmount.Text);

                var balanceAmount = Reminingcost - recivedcash;
                _selectedbooking.PaidAmount = _selectedbooking.PaidAmount + recivedcash;
                _selectedbooking.BalanceAmount = balanceAmount;
                await connection.UpdateAsync(_selectedbooking);
            }
            var mainPage = Application.Current.MainPage as MasterDetailPage;
            mainPage.Detail = new NavigationPage(new BookingList());
        }

        private void Call(object sender, EventArgs e)
        {
            PhoneDialer.Open(_selectedbooking.PhoneNo);
        }

        private async void Completed(object sender, EventArgs e)
        {
            _selectedbooking.IsCompleted = true;
            await connection.UpdateAsync(_selectedbooking);
            var mainPage = Application.Current.MainPage as MasterDetailPage;
            mainPage.Detail = new NavigationPage(new BookingList());
        }
    }
}