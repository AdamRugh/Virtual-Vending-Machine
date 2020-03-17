using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Machine
    {
        public Machine()
        {
            FileLog fileLog = new FileLog();
            fileLog.ReadFile(mainMenu);

            Balance = 0;

        }


        public Dictionary<string, Product> mainMenu = new Dictionary<string, Product>();


        public void DisplayItems()
        {
            foreach (KeyValuePair<string, Product> keyValuePair in mainMenu)
            {
                if (keyValuePair.Value.Qty == 0)
                {
                    Console.WriteLine("This item is sold out");
                }
                Console.WriteLine($"||  {keyValuePair.Key}| {keyValuePair.Value.Name.PadRight(22)}{keyValuePair.Value.Price:C2} ({keyValuePair.Value.Qty})  ||");
            }

        }
        int moneyProvided = 0;
          
        public decimal Deposit()
        {
            try
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Please insert $1, $2, $5, or $10 bill");
                moneyProvided = int.Parse(Console.ReadLine());

                if (moneyProvided == 1 || moneyProvided == 2 || moneyProvided == 5 || moneyProvided == 10)
                {                    
                    Balance += moneyProvided;
                    WriteFile("Feed Money: ", moneyProvided, Balance);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("We only accept $1, $2, $5, and $10 dollar bills");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Please only deposit whole dollar amounts");
            }
            return Balance;
        }
                
        public void GiveChange()
        {
            Console.Clear();
            int quarterCounter = 0;
            int dimeCounter = 0;
            int nickelCounter = 0;
            WriteFile("Give Change ", Balance, 0M);
            WriteFile();
            
            while (Balance >= 0.25M)
            {
                Balance -= 0.25M;
                quarterCounter++;
            }
            while (Balance >= 0.10M)
            {
                Balance -= 0.10M;
                dimeCounter++;
            }
            while (Balance >= 0.05M)
            {
                Balance -= 0.05M;
                nickelCounter++;
            }
            Console.WriteLine();
            Console.WriteLine($"Your change is: {quarterCounter} quarters, {dimeCounter} dimes, and {nickelCounter} nickels. ");
            Console.WriteLine($"Current balance is {Balance}");
            
        } 
         
        public void FinishTransaction()
        {
            GiveChange();
                       
        }
        public void Dispenser(Product product, string slot)
        {
            if (Balance >= product.Price && product.Qty > 0)
            {
                product.Qty--;
                Balance -= product.Price;
                Console.WriteLine();
                Console.WriteLine($"{product.Name.PadRight(22)}{product.Price:C2} ({Balance:C2})");
                Console.WriteLine($"{product.Message()}");
                WriteFile(product.Name + " " + slot, product.Price, Balance);
            }else if(product.Qty < 1)
            {
                Console.WriteLine();
                Console.WriteLine("This product is sold out. Please pick another item.");
            }
            else
            {
                Console.WriteLine("You have insufficient balance to purchase this item. Please enter more money");
                Console.WriteLine();
            }

        }
        public decimal Balance { get; set; }

        public int PurchaseProduct()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter the slot number for the product you would like to purchase");
            Console.WriteLine();
            string slotNumberEntered = Console.ReadLine().ToUpper();

            foreach (KeyValuePair<string, Product> keyValuePair in mainMenu)
            {
                if (!mainMenu.ContainsKey(slotNumberEntered))
                {
                    Console.WriteLine("This slot number does not exist. Please enter the valid slot number");
                    break;

                }
                else if (keyValuePair.Key.Contains(slotNumberEntered))
                {
                    Dispenser(keyValuePair.Value, keyValuePair.Key);

                    break;
                }
            }
            return 0;
        }
        private bool WriteFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"), true))
                {
                    sw.WriteLine();

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private bool WriteFile(string action, decimal money, decimal balance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"), true))
                {
                    sw.WriteLine($"{DateTime.Now} {action} {money:C2} {balance:C2} ");
                                       
                    return true;
                }
            }catch(Exception e)
            {
                return false;
            }
        }
    }
              
}
