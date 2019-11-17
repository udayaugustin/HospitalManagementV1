﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HospitalManagement.Views
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
                /*case "New Booking":
                    mainPage.Detail = new NavigationPage(new AddBooking());
                break;

                case "Booking List":
                    mainPage.Detail = new NavigationPage(new BookingListTappedPage("Today"));
                break;
                    
                case "Report":
                    mainPage.Detail = new NavigationPage(new ReportPage());
                    break;*/
            }

            mainPage.IsPresented = false;
        }

        private void Synch(object sender, EventArgs e)
        {
            mainPage = Application.Current.MainPage as MasterDetailPage;
            mainPage.Detail = new NavigationPage(new SyncData());
        }
    }
}
