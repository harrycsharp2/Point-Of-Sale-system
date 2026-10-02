using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_system
{
    public class HandleCheckout
    {
        public static string basketfilepath = "basket.txt";
        public static void HandleCheckoutMenu()
        {
            if (File.Exists(basketfilepath))
            {
                string[] lines = File.ReadAllLines(basketfilepath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("type `return` to return to main menu"); 
                Console.WriteLine("1. Purchase items");
                Console.WriteLine("2. Clear basket");
                string input = Console.ReadLine();
                if (input == "return")
                {
                    Program.Main();
                    return;
                }
                else if (input == "1")
                {
                    HandlePurchase();
                    CreateReceipt();
                    using (StreamWriter sw = new StreamWriter(basketfilepath, false))
                    {
                        sw.WriteLine("");
                    }
                    Program.Main();
                }
                else if (input == "2")
                {
                    using (StreamWriter sw = new StreamWriter(basketfilepath, false))
                    {
                        sw.WriteLine("");
                    }
                    Program.Main();
                }
                else
                {
                    HandleCheckoutMenu(); // Invalid input, show menu again
                }
            }
        }
        public static void CreateReceipt()
        {
            using (StreamWriter sw = new StreamWriter("receipt.txt", false))
            {
                sw.WriteLine("Receipt"); 
                sw.WriteLine("Items purchased:");
                string[] lines = File.ReadAllLines(basketfilepath);
                foreach (string line in lines)
                {
                    sw.WriteLine(line);
                }
            }
        }
        public static void HandlePurchase()
        {
            string[] basketLines = File.ReadAllLines(basketfilepath);
            string[] productLines = File.ReadAllLines(HandleManageProducts.productsfilepath);

            foreach (string line in basketLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string basketname = line.Split(',')[0].Trim();
                int orderamount = int.Parse(line.Split(',')[1].Trim());

                for (int i = 0; i < productLines.Length; i++)
                {
                    string productname = productLines[i].Split(',')[0].Trim();
                    int productstock = int.Parse(productLines[i].Split(',')[1].Trim());

                    if (basketname == productname)
                    {
                        int newstock = productstock - orderamount;

                        productLines[i] = $"{productname}, {newstock}";

                        break;
                    }
                }
            }

            File.WriteAllLines(
                HandleManageProducts.productsfilepath,
                productLines
            );
        }
    }
}
