using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_system;

public class Program()
{
    //THE IDEA
    //user opens application - greeted with a menu - choice to : shop, checkout, add products, remove products
    //there should be a product list where the user can add and remove products
    // there sohuld be a shop where the product list is displayed and the user can choose items which gets added the the basket
    // checkout should show the current basket were the can remove items. 
    // on checkout they should print a reciept 
    // on checkout the stock off the item they ordered should go down
    
    public static string responce;
    public static void Main()
    {
        Console.Clear();
        Console.WriteLine("Menu");
        Console.WriteLine("1. shop");
        Console.WriteLine("2. checkout");
        Console.WriteLine("3. manage products");
        Console.WriteLine("4. help");
        responce = Console.ReadLine();
        if (responce == "1")
        {
            HandleShop.HandleShopMenu();
        }
        else if (responce == "2")
        {
            HandleCheckout.HandleCheckoutMenu();
        }
        else if (responce == "3")
        {
            HandleManageProducts.HandleProductsMenu();
        }
        else if (responce == "4")
        {
            Console.WriteLine("This is a simple point of sale system. You can shop for products, checkout your basket, and manage the product list.");
            Console.WriteLine("to navigate follow the menu instructions. type 1/2/3 in some cases `return` or if the questions ask u for information like a name type a name");
            Console.ReadLine();
            Main();
        }
        else
        {
            Main();
        }
    }
}