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
                new MenuItem{ Title = "New Booking"},
                new MenuItem{ Title = "Booking List"},
                new MenuItem{ Title = "Todays Booking List"},
                new MenuItem{ Title = "Report"},
                            
            };

            listView.ItemsSource = menuList;


        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            mainPage = Application.Current.MainPage as MasterDetailPage;

            var menu = e.Item as MenuItem;
            switch (menu.Title)
            {
                case "New Booking":
                    mainPage.Detail = new NavigationPage(new AddBooking());
                break;

                case "Booking List":
                    mainPage.Detail = new NavigationPage(new BookingList());
                break;
                case "Todays Booking List":
                    mainPage.Detail = new NavigationPage(new BookingList(true));
                    break;
                case "Report":
                    mainPage.Detail = new NavigationPage(new ReportPage());
                    break;
            }

            mainPage.IsPresented = false;
        }


    }
}
