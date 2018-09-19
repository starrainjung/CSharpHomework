using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组长度");
            int len;
            len = Convert.ToInt32(Console.ReadLine());
            int[] num = new int[len];//建数组

            //输入数组数据
            Console.Write("请输入数据:");
            for (int i = 0; i < len; i++)
            {
                num[i] = Convert.ToInt32(Console.ReadLine());
            }

            //算各项数据
            int Max = num[0], Min = num[0], Sum = 0;
            double Ave;
            for (int i = 0; i < len; i++)
            {
                if (num[i] > Max)
                    Max = num[i];
                if (num[i] < Min)
                    Min = num[i];
                Sum = Sum + num[i];
            }
            Ave = Sum / len;
            Console.WriteLine("最大值:" + Max);
            Console.WriteLine("最小值;" + Min);
            Console.WriteLine("平均数:" + Ave);
            Console.WriteLine("和:" + Sum);

        }
    }
}
