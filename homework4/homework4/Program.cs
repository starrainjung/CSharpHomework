using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 总体仿照书上p149页例题
     */
namespace homework4
{

    public class ClockEventArgs : EventArgs                                     
    {
        public string SetTime
        {
            set; get;
        }
    }

    public delegate void ClockEventHandler(object sender, ClockEventArgs time); 

    public class Clock                                                          
    {
        public event ClockEventHandler Warning;      //声明事件                           
        public void Time()
        {
            ClockEventArgs setClocktime = new ClockEventArgs();                    
            setClocktime.SetTime = Console.ReadLine();                             
            while (true)
            {
                string systemTime = DateTime.Now.ToShortTimeString().ToString();     //获取系统时间

                if (systemTime == setClocktime.SetTime)                             
                {
                    Warning(this, setClocktime);
                    break;
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("请设定闹钟时间（格式为00:00）： ");
            var clock = new Clock();
            //注册事件
            clock.Warning += ClockWarning;
            clock.Time();

        }

        //事件处理方法
        static void ClockWarning(object sender, ClockEventArgs time)
        {
            Console.WriteLine("时间到");
        }
    }
}
