using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework7
{
    class Order
    {
            public string orderNumber { get; set; }

            public string guestName { get; set; }

            public string goodsName { get; set; }
            public int goodsPrice { get; set; }



            public Order(string orderNumber, string guestName, string goodsName, int goodsPrice)
            {
                this.orderNumber = orderNumber;
                this.guestName = guestName;
                this.goodsName = goodsName;
                this.goodsPrice = goodsPrice;
            }

            public Order() { }

            public void ShowOrder()
            {
                Console.Write(orderNumber + " " + guestName + " " + goodsName + " " + goodsPrice);
            }

        }
    }

