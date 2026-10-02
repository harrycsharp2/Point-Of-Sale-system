using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace POS_system
{
    public class HandleShop
    {
        public static string productsfilepath = "products.txt";
        public static string basketfilepath = "basket.txt";
        public static void HandleShopMenu()
        {
            List<product> products = new List<product>();
            if (!File.Exists(basketfilepath))
            {
                using (StreamWriter sw = new StreamWriter(basketfilepath))
                {
                    sw.WriteLine("");
                }
            }
            if (File.Exists(productsfilepath))
            {
                int i = 1;
                string[] lines = File.ReadAllLines(productsfilepath);
                foreach (string line in lines)
                {
                    product product2 = new product();
                    product2.name = line.Split(',')[0];
                    product2.stock = int.Parse(line.Split(',')[1]);
                    products.Add(product2);
                    Console.WriteLine($"{i}.");
                    Console.WriteLine($"{product2.name} - Stock: {product2.stock}");
                    i++;
                }
                
                Console.WriteLine("type `return` to return to main menu");
                Console.WriteLine("enter product name you want to buy");
                string name = Console.ReadLine();
                
                if (name == "return")
                {
                    Program.Main();
                    return;
                }
                
                Console.WriteLine("enter amount of the product you want to buy // `return` to return");
                string amount = Console.ReadLine();
                
                if (amount == "return")
                {
                    Program.Main();
                    return;
                }

                string ordereditem = $"{name}, {amount}";
                product selectedproduct = products.FirstOrDefault(
                    p => p.name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (selectedproduct != null 
                    && File.Exists(basketfilepath) 
                    && int.TryParse(amount, out int orderedAmount) 
                    && orderedAmount <= selectedproduct.stock)
                {
                    using (StreamWriter sw = new StreamWriter(basketfilepath, true))
                    {
                        sw.WriteLine($"{selectedproduct.name}, {orderedAmount}");
                    }
                }
                Program.Main();
               
            }
        }
    }
}
