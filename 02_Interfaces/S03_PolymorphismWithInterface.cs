using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PolymorphismWithInterface
{
    public interface IFigure
    {
        Point Location { get; set; }
        bool Contains(Point p);
        double Area { get; }
    }

    //Расширение интерфейса IFigure методом Contains, которому передается массив точек
    public static class IFigureExtensions
    {
        public static bool Contains(this IFigure obj, Point[] points)
        {
            foreach (var p in points)
                if (obj.Contains(p)) return true;
            return false;
        }
    }

    class Square : IFigure
    {
        public Point Location { get; set; }
        public int Size { get; set; }
        public bool Contains(Point p)
        {
            return
                Math.Abs(p.X - Location.X) < Size / 2 &&
                Math.Abs(p.Y - Location.Y) < Size / 2;
        }
        public double Area
        {
            get { return Math.Pow(Size, 2); }
        }
    }

    class Circle : IFigure
    {
        public Point Location { get; set; }
        public int Radius { get; set; }
        public bool Contains(Point p)
        {
            return
                Math.Sqrt(Math.Pow(p.X - Location.X, 2) + Math.Pow(p.Y - Location.Y, 2)) < Radius;
        }
        public double Area
        {
            get { return Math.PI * Math.Pow(Radius, 2); }
        }
    }

    public class Program
    {
        static void MainX(string[] args)
        {
            var scene = new List<IFigure>
            {
                new Square { Location=new Point(0,0), Size=2 },
                new Circle { Location=new Point(1,1), Radius=3 },
            };

            var point = new Point(1, 0);
            foreach (var e in scene)
                Console.WriteLine(e.Contains(point));

            foreach (var e in scene)
            {
                if (e is Square) Console.Write("Square. ");
                else Console.Write("Circle. ");
                Console.WriteLine("Area = " + e.Area);
            }

            scene[0].Contains(new Point(2, 3)); //метод, реализованный в классе
            //метод расширения, реализованный для интерфейса IFigure
            scene[0].Contains(new Point[]{new Point(1,2), new Point(3,3), new Point(2,5) });
        }
    }
}
