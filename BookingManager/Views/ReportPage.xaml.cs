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
	public partial class ReportPage : ContentPage
	{
        SQLiteAsyncConnection connection;
        List<Booking> bookingList;

        public ReportPage ()
		{
			InitializeComponent ();
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            GetData();
        }

        private async void GetData()
        {
            bookingList = new List<Booking>();
            bookingList = await connection.Table<Booking>().ToListAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var From = Fromdate.Date;
            var To = Todate.Date;           
            bookingList = bookingList.Where(b => b.CheckinDate.Date <= From && b.CheckinDate.Date >= To).ToList();
            listview.ItemsSource = bookingList;
        }
    }
}