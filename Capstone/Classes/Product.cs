using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public abstract class Product
    {
        public Product(decimal itemPrice, string itemName, int itemQty)
        {
            Price = itemPrice;
            Name = itemName;
            Qty = itemQty;
        }

        public virtual string Slot { get; }

        public virtual decimal Price { get; }

        public virtual string Name { get; }
        public virtual string Message()
        {
            return "";
        }

        public virtual int Qty { get; set; }



    }
}
