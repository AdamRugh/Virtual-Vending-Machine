using Capstone.Classes;
using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileLog fL = new FileLog();
            //fL.ReadFile();

            Console.WriteLine("Welcome to Vendo-Matic 800!!!");
            Menu theStartMenu = new Menu();
            theStartMenu.MainMenu(true);
            
            


        }
    }
}
