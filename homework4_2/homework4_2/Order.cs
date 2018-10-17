using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
   public  class Order
    {
        public string orderNumber { get; set; }
       
        public string guestName { get; set; }

        public string goodsName { get; set; }
        public double goodsPrice { get; set; }

       

        public Order(string orderNumber, string guestName, string goodsName, double goodsPrice)
        {
            this.orderNumber = orderNumber;
            this.guestName = guestName;
            this.goodsName = goodsName;
            this.goodsPrice = goodsPrice;
        }



        public void ShowOrder()
        {
            Console.Write(orderNumber + " " + guestName + " " + goodsName + " " + goodsPrice);
        }

    }
}