using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Chip :Product
    {
        public Chip(decimal itemPrice, string itemName, int itemQty) : base(itemPrice, itemName, itemQty)
        {
           
        }

        public override string Message()
        {
            return "Crunch Crunch, Yum!";
        }

    }
}
