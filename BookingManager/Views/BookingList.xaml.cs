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
    public partial class BookingList : ContentPage
    {
        SQLiteAsyncConnection connection;
        List<Booking> bookingList;
        private bool isShowOnlyTodayList;

        public BookingList(bool isShowOnlyTodayList = false)
        {
            InitializeComponent();

            this.isShowOnlyTodayList = isShowOnlyTodayList;
            if (isShowOnlyTodayList)
            {
                Title = "Todays Booking List ";
            }
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            GetData();

        }

        private async void GetData()
        {
            bookingList = new List<Booking>();

            bookingList = await connection.Table<Booking>().ToListAsync();
            bookingList = bookingList.Where(b => b.IsCompleted == false).ToList();
            if(isShowOnlyTodayList)
                bookingList = bookingList.Where(b => b.CheckinDate == DateTime.Today.Date).ToList();
            listview.ItemsSource = bookingList;

        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            var editmenuItem = sender as Xamarin.Forms.MenuItem;

            if (editmenuItem != null)
            {
                var booking = editmenuItem.BindingContext as Booking;

                if (booking != null)
                {
                   await Navigation.PushAsync(new EditBooking(booking));
                }
            }
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var deletemenuItem = sender as Xamarin.Forms.MenuItem;

            if (deletemenuItem != null)
            {
                var booking = deletemenuItem.BindingContext as Booking;

                if (booking != null)
                {
                    await connection.DeleteAsync(booking);

                }
                
            }

        }

        private async void Listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var booking = e.Item as Booking;

            await Navigation.PushAsync(new BookingDetail(booking));
        }
    }
}