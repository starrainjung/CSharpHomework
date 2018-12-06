using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    [Serializable]
    public class Goods
    {
        public Goods() { }
        public Goods(int id, string name, double value)
        {
            GoodId = id;
            GoodName = name;
            Price = value;
        }
        
        public int GoodId { get; set; }
        public string GoodName { get; set; }

        public double price;
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value must >= 0!");
                price = value;
            }
        }

        public override string ToString()
        {
            return $"GoodId:{GoodId}, GoodName:{GoodName}, Value:{Price}";
        }
    }
}
