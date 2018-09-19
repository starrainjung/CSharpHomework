using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入数据:");

            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("该数据的素数因子有:");
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    bool right = true;
                    for (int j = 2; j <= Math.Sqrt(i); j++)        //防止出现不是素数的因子
                    {
                        if (i % j == 0)             
                        {
                            right = false;
                        }                         
                    }
                    if (right)
                    {
                        Console.Write(i+";"); 
                    }
                }
            }
        }
    }
}
