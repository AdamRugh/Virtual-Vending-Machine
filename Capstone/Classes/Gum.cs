using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Gum : Product
    {
        public Gum(decimal itemPrice, string itemName, int itemQty) : base(itemPrice, itemName, itemQty)
        {

        }
        public override string Message()
        {
            return "Chew Chew, Yum!";
        }
    }
}
