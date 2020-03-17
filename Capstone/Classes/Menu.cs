using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Menu
    {
        public Menu()
        {
            

        }     
          

        Machine vendo = new Machine();
        public bool MainMenu(bool usingMainMenu)
        {
            
           
            while (usingMainMenu)
            {
                try
                {
                    
                    Console.WriteLine();
                    Console.WriteLine("> (1) Display Vending Machine Items > (2) Purchase > (3) Exit >");
                    int UserMainMenuChoice = int.Parse(Console.ReadLine());
                    if (UserMainMenuChoice == 1)
                    {                        
                        Console.Clear();
                        Console.WriteLine("===========================================");
                        vendo.DisplayItems();                        
                        Console.WriteLine("===========================================");
                        continue;
                    }
                    else if (UserMainMenuChoice == 2)
                    {
                        Console.Clear();
                        PurchaseMenu(true);

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Thank you for using Vendo-Matic 800!!!");
                        usingMainMenu = false;
                    }
                } catch(Exception e)
                {
                    Console.WriteLine("Please enter 1 for Display Vending Machine Items, 2 for Purchase, or 3 for Exit");
                    Console.WriteLine();
                }
            }
            return true;

        }
      
        public bool PurchaseMenu(bool usingPurchaseMenu)
        {
            while (usingPurchaseMenu)
            {
                try
                {
                    
                    Console.WriteLine();
                    Console.WriteLine($" > (1) Feed Money > (2) Select Product > (3) Finish Transaction > > Current Money Provided: {vendo.Balance:C2} >");
                    int UserMainMenuChoice = int.Parse(Console.ReadLine());
                    if (UserMainMenuChoice == 1)
                    {
                        vendo.Deposit();
                        usingPurchaseMenu = true;

                    }
                    else if (UserMainMenuChoice == 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("===========================================");
                        vendo.DisplayItems();
                        Console.WriteLine("===========================================");
                        
                        vendo.PurchaseProduct();
                        usingPurchaseMenu = true;
                    }
                    else
                    {
                        vendo.FinishTransaction();
                        Console.WriteLine("Thank you for using Vendo-Matic 800!!!");
                        usingPurchaseMenu = false;
                        
                    }
                }catch (Exception e)
                {
                    Console.WriteLine("Please enter 1 for Feed Money, 2 for Select Product, or 3 for Finish Transaction");
                    Console.WriteLine();
                }
            }
            return true;

        }

    }
}
