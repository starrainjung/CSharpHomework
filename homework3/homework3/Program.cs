using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    
   public class Shape
    {
        public double numWidth;// 长方形的宽
        public double numLength;// 长方形的长
        public double a;
        public double b;
        public double c; // 三角形的三条边
        public double numSide;//正方形的边
        public double numRadius; //圆的半径 

        public virtual double S()
        {
            return 0;
        }

    }
    class Triangle : Shape
    {
        public override double S()
        {
            Console.WriteLine("请输入正确的三个边长：");
            a = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
            c = double.Parse(Console.ReadLine());
            double p = (a + b + c) / 2;
        
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }

    class Circle : Shape
    {
        public override double S()
        {
            Console.WriteLine("请输入半径：");
            numRadius= double.Parse(Console.ReadLine());
           
           

            return numRadius * numRadius * 3.14;
        }
    }

    class Rectangle : Shape
    {
        public override double S()
        {
            Console.WriteLine("请输入长和宽：");
            numLength = double.Parse(Console.ReadLine());
            numWidth = double.Parse(Console.ReadLine());
           
            return numWidth * numLength;
        }
    }

    class Square : Shape
    {
        public override double S()
        {
            Console.WriteLine("请输入边长：");
            numSide= double.Parse(Console.ReadLine());

            return numSide * numSide;;
        }
    }

  class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("请输入图形类型：");

            string type = "";
            type = Console.ReadLine();
            Shape shape = null;
            try { 
            if (type.Equals("Triangle"))
            {
                shape = new Triangle();
                Console.WriteLine("面积为：" + shape.S());
                }
            else if (type.Equals("Circle"))
            {
                shape = new Circle();
                    Console.WriteLine("面积为：" + shape.S());
                }
            else if (type.Equals("Square"))
            {
                shape = new Square();
                    Console.WriteLine("面积为：" + shape.S());
                }
            else if (type.Equals("Rectangle"))
            {
                shape = new Rectangle();
                    Console.WriteLine("面积为：" + shape.S());
                }
            else
            {
                Console.WriteLine("请输入规定的字符！");
            }
        }
            
            catch
            {
            }

           

       
        }
    }


}
