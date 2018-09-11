using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "";
            string s2 = "";
            int num1 = 0;
            int num2 = 0;
            Console.Write("Please input num1:");
            s1 = Console.ReadLine();
            num1 = int.Parse(s1);
            Console.Write("Please input num2:");
            s2 = Console.ReadLine();
            num2 = int.Parse(s2);
            Console.WriteLine("num1 * num2 =" + num1 * num2);
        }
    }
}
