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
    public partial class MasterPage : MasterDetailPage
    {
        MasterDetailPage mainPage;
        public MasterPage()
        {
            InitializeComponent();

            SetupMenu();
        }

        public void SetupMenu()
        {
            var menuList = new List<MenuItem>
            {
                new MenuItem{ Title = "Add Booking"},
                new MenuItem{ Title = "Booking List"},
                new MenuItem{ Title = "Todays Booking List"},
                new MenuItem{ Title = "All Bookings"},
                new MenuItem{ Title = "Update Payment"},                
            };

            listView.ItemsSource = menuList;


        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            mainPage = Application.Current.MainPage as MasterDetailPage;

            var menu = e.Item as MenuItem;
            switch (menu.Title)
            {
                case "Add Booking":
                    mainPage.Detail = new NavigationPage(new AddBooking());
                break;

                case "Booking Report":
                    mainPage.Detail = new NavigationPage(new AddBooking());
                break;
            }

            mainPage.IsPresented = false;
        }


    }
}
