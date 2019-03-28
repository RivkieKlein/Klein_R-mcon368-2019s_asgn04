using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {

            Sale sale1 = new Sale();
            sale1.Item = "Tea";
            sale1.Customer = "LLC";
            sale1.PricePerItem = 10.0;
            sale1.Quantity = 10;
            sale1.Address = "13 Park lane";
            sale1.ExpeditedShipping = false;

            Sale sale2 = new Sale();
            sale2.Item = "Coffee";
            sale2.Customer = "javabean llc";
            sale2.PricePerItem = 11.0;
            sale2.Quantity = 10;
            sale2.Address = "25 bridge lane";
            sale2.ExpeditedShipping = true;

            Sale sale3 = new Sale();
            sale3.Item = "Candy";
            sale3.Customer = "sweet treats";
            sale3.PricePerItem = 9.0;
            sale3.Quantity = 1;
            sale3.Address = "10 river street";
            sale3.ExpeditedShipping = false;

            Sale sale4 = new Sale();
            sale4.Item = "Skis";
            sale4.Customer = "Snow Gear LLC";
            sale4.PricePerItem = 100.0;
            sale4.Quantity = 1;
            sale4.Address = "2 Mountain Drive";
            sale4.ExpeditedShipping = false;

            Sale sale5 = new Sale();
            sale5.Item = "Book";
            sale5.Customer = "readers inc.";
            sale5.PricePerItem = 5.0;
            sale5.Quantity = 20;
            sale5.Address = "2047 8th ave";
            sale5.ExpeditedShipping = true;

            Sale[] sales = { sale1, sale2, sale3, sale4, sale5 };

            //4a Part I:
            //1.
            var salePriceOver10 = sales.Where(s => s.PricePerItem > 10.0);

            //2.
            var saleQuant1Ordered = sales.Where(s => s.Quantity == 1).OrderByDescending(s=>s.PricePerItem);

            //3
            var saleTeaNotExpedited = sales.Where(s => s.Item == "Tea" && !s.ExpeditedShipping);

            //4
            var addressesCostOver100 = sales.Where(s=>(s.PricePerItem*s.Quantity)>100.0).Select(e => e.Address);

            //5
            //var anonymous = sales.Select(new)

            //Tests for Part II TotalProfit
            Console.WriteLine($"Total Profit: {TotalProfit(sales, s => s.Item == "Coffee", s=>.8*(s.PricePerItem*s.Quantity), (s, d)=>Console.WriteLine($"Coffee item for {s.Customer}, total profit: {d}"),s=>Console.WriteLine("Non Coffee Item Skipping"))}");
            //not following second example exactly
            Console.WriteLine($"Total Profit: {TotalProfit(sales, s => s.Quantity >1, s =>  (s.PricePerItem * s.Quantity)+ (s.ExpeditedShipping ? 20 : 0), (s, d) => Console.WriteLine($"Order with quantity greater than one for {s.Customer}, total profit: {d}"), s => Console.WriteLine("Quantity not more than one. Skipping"))}");
            Console.Read();
        }

        //Method for Part II
        public static double TotalProfit(Sale[] sales, Func<Sale, bool> Included, Func<Sale, double> totalProfitDeterminer, Action<Sale,double> specifyActionProfit, Action<Sale>  specifyActionNotIncluded)
        {
            double total = 0;
            foreach(Sale sale in sales){
                if (Included(sale))
                {
                    
                    double profit = totalProfitDeterminer(sale);
                    specifyActionProfit(sale, profit);
                    total += profit;
                }
                else
                {
                    specifyActionNotIncluded(sale);
                }
            }

            return total;
        }
        
    }
}
