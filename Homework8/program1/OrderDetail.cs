using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*

     */
namespace program1
{
    [Serializable]
    public class OrderDetail
    {
        public double amount { get; set; }
        public OrderDetail(){ }
        public OrderDetail(int id, Goods goods, int quantity)
        {
            this.Id = id;
            this.Goods = goods;
            this.Quantity = quantity;
            amount = Quantity * goods.Price;
        }

        public int Id { get; set; }

        public Goods Goods { get; set; }

        public int Quantity { get; set; }

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetail;
            return detail != null &&
                Goods.GoodId == detail.Goods.GoodId &&
                Quantity == detail.Quantity;
        }

        public override int GetHashCode()
        {
            var hashCode = 1522631281;
            hashCode = hashCode * -1521134295 + Goods.GoodName.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            string result = "";
            result += $"orderDetailId:{Id}:  ";
            result += Goods + $", quantity:{Quantity}"+ $",  amount:{amount}";
            return result;
        }
    }
}
