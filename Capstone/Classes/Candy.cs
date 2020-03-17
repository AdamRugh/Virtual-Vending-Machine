using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy : Product
    {
        public Candy(decimal itemPrice, string itemName, int itemQty) : base(itemPrice, itemName, itemQty)
        {

        }
        public override string Message()
        {
            return "Munch Munch, Yum!";
        }
    }
}
