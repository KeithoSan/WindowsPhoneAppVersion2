using cfApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using System.Net.Http.Headers;

namespace cfApp
{

    public sealed partial class makeReviewPage : Page
    {
        public makeReviewPage()
        {
            this.InitializeComponent();
        }
        private const String serviceURI = "http://coffeelocatorwebservice.cloudapp.net/";
  
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void sortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void addReview_Click(object sender, RoutedEventArgs e)
        {
          
      
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                    //get eircode value
                    string Value = "";
                    if (Eircode.SelectedIndex >= 0)
                        Value = ((ComboBoxItem)Eircode.SelectedItem).Content.ToString();

                    //create new review
                    Review review = new Review() { CustomerName = custText.Text, CustomerEmail = emailText.Text, Comment = commentText.Text, Eircode = Value, ReviewDate = DateTime.Now, Rating = 3 };

                    client.DefaultRequestHeaders.
                            Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //mock data
                  //  Review review = new Review() { CustomerName = "Stevo", CustomerEmail = "stevo@yahoo.com", ReviewDate = DateTime.Now, Eircode = "C15CK3E", Comment = "It was great", Rating = 4 };

                        HttpResponseMessage response = await client.PostAsJsonAsync("api/CoffeeStore", review);             // or PostAsXmlAsync

                        if (response.IsSuccessStatusCode)                                                   // 200.299
                        {  
                        }
                        else
                        {    
                        }
                    }
                }
                catch (HttpRequestException)
                {
                  
                }
            }
       
       
        private void Eircode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //
        }

        private void textBlock2_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //
        }

        private void textBlock3_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //
        }

        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }
    }
}
