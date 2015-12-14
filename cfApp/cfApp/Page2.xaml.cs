using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using cfApp.Models;

namespace cfApp
{
 
    public sealed partial class Page2 : Page
    {
        private const String serviceURI = "http://coffeelocatorwebservice.cloudapp.net/";
        public Page2()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(serviceURI);

                    // add an Accept header for JSON
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //get the eircode value
                    string Value = "";
                    if (eircode.SelectedIndex >= 0)
                    {
                        Value = ((ComboBoxItem)eircode.SelectedItem).Content.ToString();
                    }
                    //1.
                    //get isOpen/ hasWifi/ with eircode
                    if ((isOpen.IsChecked == false) && (hasWifi.IsChecked == true))
                    {

                        HttpResponseMessage response = await client.GetAsync("CoffeeStore/eircode/isOpen/hasWifi/" + Value);

                        if (response.IsSuccessStatusCode)
                        {
                            var coffeestores = await response.Content.ReadAsAsync<IEnumerable<CoffeeStore>>();
                            listView.ItemsSource = new ObservableCollection<CoffeeStore>(coffeestores);
                        }

                        else { }
                    }

                    //2.
                    //get  hasWifi/ with eircode
                    else if ((isOpen.IsChecked == true) && (hasWifi.IsChecked == true))
                    {
                        HttpResponseMessage response = await client.GetAsync("CoffeeStore/eircode/hasWifi/" + Value);

                        if (response.IsSuccessStatusCode)
                        {
                            // read results 
                            var coffeestores = await response.Content.ReadAsAsync<IEnumerable<CoffeeStore>>();
                            listView.ItemsSource = new ObservableCollection<CoffeeStore>(coffeestores);
                        }
                        else { }
                    }

                    //3.
                    //get isOpen/  with eircode
                    else if ((isOpen.IsChecked == true) && (hasWifi.IsChecked == false))
                    {
                        HttpResponseMessage response = await client.GetAsync("CoffeeStore/eircode/isOpen/" + Value);

                        if (response.IsSuccessStatusCode)
                        {
                            // read results 
                            var coffeestores = await response.Content.ReadAsAsync<IEnumerable<CoffeeStore>>();
                            listView.ItemsSource = new ObservableCollection<CoffeeStore>(coffeestores);
                        }
                        else { }
                    }
                    //4.
                    //get with eircode
                    else  
                    {
                        HttpResponseMessage response = await client.GetAsync("CoffeeStore/eircode/" + Value);

                        if (response.IsSuccessStatusCode)
                        {
                            // read results 
                            var coffeestores = await response.Content.ReadAsAsync<IEnumerable<CoffeeStore>>();
                            listView.ItemsSource = new ObservableCollection<CoffeeStore>(coffeestores);
                        }
                        else { }
                    }

                }

            }
            catch (HttpRequestException) { }
        }
                
//Go back to previous page
        private void backToMain_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
//go to make a review page
        private void makeReview_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(makeReviewPage));
        }
    }
}
