using System;
using System.Threading;

namespace TimerUsingActionDelegate
{
    public class Timer
    {
        public int Interval; //интервал между тиками
        public Action Tick;  //тик-так

        public void Start()
        {
            while (true)
            {
                if (Tick != null) // если в Tick ничего не присвоить и вызвать, будет NullReferenceException
                    Tick();
                Thread.Sleep(Interval); // ждет заданное время
            }
        }
    }

    public class Program
    {
        public static void MainX()
        {
            var timer = new Timer();
            timer.Interval = 1000;
            //Назначаем действие Action-делегату
            timer.Tick = () => Console.WriteLine("Tick!");
            timer.Start();
        }
    }
}
