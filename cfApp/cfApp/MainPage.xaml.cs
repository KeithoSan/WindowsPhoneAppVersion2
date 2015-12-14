using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using cfApp.Models;
using Newtonsoft.Json;



namespace cfApp
{

    public sealed partial class MainPage : Page
    {
        private const String serviceURI = "http://coffeelocatorwebservice.cloudapp.net/"; 
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //created mock data
            List<CoffeeStore> myStores = new List<CoffeeStore>() { new CoffeeStore() { Eircode = "T12GH46", City = City.Dublin, OpeningTime = OpeningHour.AM0700, ClosingTime = ClosingHour.PM1800, Location = "dublin fair city", StoreName = "charleys", hasWifi = true },
               new CoffeeStore() { Eircode = "D02JF46", City = City.Dublin, OpeningTime = OpeningHour.AM0500, ClosingTime = ClosingHour.PM1800, Location = "Parnell St. Dublin 2", StoreName = "Petit Cafe", hasWifi = true },
                 new CoffeeStore() { Eircode = "V94TE8D", City = City.Limerick, OpeningTime = OpeningHour.AM0700, ClosingTime = ClosingHour.PM1830, Location = "9 O' Connell st ", StoreName = "Insomnia", hasWifi = false },
             new CoffeeStore() { Eircode = "V94GH46", City = City.Limerick, OpeningTime = OpeningHour.AM0700, ClosingTime = ClosingHour.PM1800, Location = "limerick fair city", StoreName = "cafe noir", hasWifi = false }};


            listView.ItemsSource = new ObservableCollection<CoffeeStore>(myStores);
   
        }

        private void eircodeSearch_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page2));
        }

        private void makeReview_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(makeReviewPage));
        }
    }
    }
    

