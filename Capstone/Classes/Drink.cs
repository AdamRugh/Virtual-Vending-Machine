using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Drink : Product 
    {
        public Drink(decimal itemPrice, string itemName, int itemQty): base(itemPrice, itemName, itemQty)
        {

        }
        public override string Message()
        {
            return "Glug Glug, Yum!";
        }
    }
}
