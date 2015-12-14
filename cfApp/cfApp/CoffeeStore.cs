using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfApp.Models
{
    public enum OpeningHour
    {

        AM0500 = 0500,
        AM0600 = 0600,
        AM0700 = 0700,

        AM0800 = 0800,

        AM0830 = 0830,

        AM0900 = 0900
    }
    public enum ClosingHour
    {

        PM1600 = 1600,

        PM1700 = 1700,

        PM1730 = 1730,

        PM1800 = 1800,

        PM1830 = 1830,

        PM1900 = 1900
    }
    // public enum Rating {[Display(Name = "1")]one = 1, [Display(Name = "2")]two, [Display(Name = "3")]three, [Display(Name = "4")]four, [Display(Name = "5")]five }
    public enum City { Limerick, Cork, Dublin }
    public class CoffeeStore
    {
        //Store name

        public String StoreName { get; set; }

        //Eircode

        // eircode is a 7 character code, 3 char routing key (A..Z, 0..9)
        // followed by 4 char unique ID (A..Z, 0..9)

        public String Eircode { get; set; }

        //Location

        public String Location { get; set; }

        //opening/closing hours
        public bool IsOpen
        {
            get
            {
                long n = long.Parse(DateTime.Now.ToString("HHmm"));
                if ((n >= (int)OpeningTime) && (n <= (int)ClosingTime))
                {
                    return true;
                }
                else { return false; }
            }
        }
        public OpeningHour OpeningTime { get; set; }


        public ClosingHour ClosingTime { get; set; }

        //get overall rating score
        public double? StoreRating
        {
            get;

        }


        //City - Limerick, Cork or Dublin
        public City City { get; set; }

        //does store have wifi

        public bool hasWifi { get; set; }
        public override string ToString()
        {
            return "Eircode: " + Eircode + " Store Name: " + StoreName + " City: " + City + " Location: " + Location + " Store Rating: " + StoreRating + " Has WIFI: " + hasWifi + " Is Open: " + IsOpen;
        }

        //  public virtual ICollection<Drink> Drinks { get; set; }
        //  public virtual ICollection<Review> Reviews { get; set; }
    }

    public class Review
    {
        //Review ID
        public int ReviewID { get; set; }

        //Customer's name

        public String CustomerName { get; set; }

        //Customer's email

        public String CustomerEmail { get; set; }

        //Make a comment

        public String Comment { get; set; }

        //Rate the store 1 = bad .... 5 = excellent

        public int Rating { get; set; }

        //Review date
        private DateTime reviewDate = DateTime.Now;

        public DateTime ReviewDate { get { return reviewDate; } set { reviewDate = value; } }

        //Eircode is the foreign key
        public String Eircode { get; set; }
        public virtual CoffeeStore CoffeeStore { get; set; }
    }
    public class Drink
    {

        public int DrinkID { get; set; }

        //Drink Name

        public String DrinkName { get; set; }

        //coffee price
        public double Price { get; set; }

        public String Eircode { get; set; }
        public virtual CoffeeStore CoffeeStore { get; set; }

    }





}
