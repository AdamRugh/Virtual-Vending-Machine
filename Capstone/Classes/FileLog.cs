using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class FileLog
    {

        string slot = "";
        decimal price = 0M;
        string name = "";
        string type = "";
        int qty = 5;

        public void ReadFile(Dictionary<string, Product> mainMenu)
        {
            string directory = Directory.GetCurrentDirectory();
            string filename = "vendingmachine.csv";
            string path = Path.Combine(directory, filename);


            try
            {
                using(StreamReader sr = new StreamReader(path))
                {
                    
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();

                            string[] productArray = line.Split('|');
                            slot = productArray[0];
                            name = productArray[1];
                            price = decimal.Parse(productArray[2]);
                            type = productArray[3];


                            if (type == "Chip")
                            {
                                Chip chipName = new Chip(price, name, qty);
                                mainMenu.Add(slot, chipName);

                            }
                            else if (type == "Candy")
                            {
                                Candy candyName = new Candy(price, name, qty);
                                mainMenu.Add(slot, candyName);
                            }
                            else if (type == "Gum")
                            {
                                Gum gumName = new Gum(price, name, qty);
                                mainMenu.Add(slot, gumName);
                            }
                            else if (type == "Drink")
                            {
                                Drink drinkName = new Drink(price, name, qty);
                                mainMenu.Add(slot, drinkName);
                            }
                            
                        }
                }
            }catch(Exception e)
            {

            }
           

        }




    }
}
