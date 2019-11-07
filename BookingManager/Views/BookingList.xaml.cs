﻿using SQLite;
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

        public BookingList()
        {
            InitializeComponent();
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            GetData();

        }

        private async void GetData()
        {
            bookingList = new List<Booking>();
            bookingList = await connection.Table<Booking>().ToListAsync();
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

        private async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           var booking = e.SelectedItem as Booking;

            await Navigation.PushAsync(new BookingDetail(booking));
        }
    }
}