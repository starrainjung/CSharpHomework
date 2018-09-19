using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2到100间的素数有：");
            for (int i = 2; i < 100; i++)
            {
                for (int j = 2; j <= i; j++)
                {
                    /* 用i循环
                      如果i除以j无余则说明i不为素数，跳出j循环
                       如果i除以j有余则加大j，直到ij相等都有余则i为素数
                   */
                    if (i % j == 0 && j < i) break;


                    if (i % j != 0) continue;
                     else Console.WriteLine(i);
                }
            }
        }
    }
}
