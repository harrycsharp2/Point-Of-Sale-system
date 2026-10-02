using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace POS_system
{
    public class HandleManageProducts
    {
        public static string productsfilepath = "products.txt";
        public static string responce;
        public static void HandleProductsMenu()
        {
            if (!File.Exists(productsfilepath))
            {
                using (StreamWriter sw = new StreamWriter(productsfilepath))
                {
                    sw.Write("");
                }
            }
            
            Console.Clear();
            Console.WriteLine("1. add product");
            Console.WriteLine("2. remove product");
            Console.WriteLine("3. edit product");
            Console.WriteLine("4. view products");
            Console.WriteLine("5. return");
            responce = Console.ReadLine();
            
            if (responce == "1")
            {
                HandleAddingProducts();
            }
            else if (responce == "2")
            {
                HandleRemovingProducts();
            }
            else if (responce == "3")
            {
                HandleEditProducts();
            }
            else if (responce == "4")
            {
                string[] lines = File.ReadAllLines(productsfilepath);
                int i = 1;
                foreach (string line in lines)
                {
                    Console.WriteLine($"{i}.");
                    Console.WriteLine($"{line}");
                    i++;
                }
                Console.ReadLine();
                HandleProductsMenu();
            }
            else if (responce == "5")
            {
                Program.Main();
            }
            else
            {
                Console.WriteLine("invalid responce");
            }
        }
        public static void HandleAddingProducts()
        {
            Console.Clear();
            
            Console.WriteLine("product name");
            string name = Console.ReadLine();

            Console.WriteLine("product stock");
            string p = Console.ReadLine();
            
            int stock;
            if (int.TryParse(p, out stock)) ;
            else Program.Main();

            if (File.Exists(productsfilepath))
            {
                using (StreamWriter sw = new StreamWriter(productsfilepath, true))
                {
                    sw.WriteLine($"{name}, {stock}");
                }
            }
            HandleProductsMenu();
        }
        public static void HandleRemovingProducts()
        {
            Console.Clear();
            
            Console.WriteLine("product name you want to remove // type `all` to remove all");
            string name = Console.ReadLine();
            if (name == "all")
            {
                using (StreamWriter sw = new StreamWriter(productsfilepath, false))
                {
                    sw.WriteLine("");
                    
                }
                HandleProductsMenu();
                return;
            }
            Console.WriteLine("product stock you want to remove");
            string stock = Console.ReadLine();

            string wanted2remove = $"{name}, {stock}";
            if (File.Exists(productsfilepath) )
            {
                string[] lines = File.ReadAllLines(productsfilepath);
                lines = lines.Where(line => line != wanted2remove).ToArray();
                File.WriteAllLines(productsfilepath, lines);
            }
            
            HandleProductsMenu();
        }
        public static void HandleEditProducts()
        {
            Console.Clear();
            Console.WriteLine("product name ");
            string name = Console.ReadLine();
           
            Console.WriteLine("product current stock");
            string stock = Console.ReadLine();

            Console.WriteLine("new stock // type `return` to return");
            string newstock = Console.ReadLine();

            if (name == "return")
            {
                HandleProductsMenu();
                return;
            }

            string want2edit = $"{name}, {stock}";
            string newedit = $"{name}, {newstock}";
            if (File.Exists(productsfilepath))
            {
                string[] lines = File.ReadAllLines(productsfilepath);

                lines = lines
                    .Select(line => line == want2edit ? newedit : line)
                    .ToArray();

                File.WriteAllLines(productsfilepath, lines);
            }
            HandleProductsMenu();
        }
    }
}
