using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Figures
{
    class Figure
    {
        public Point Location { get; set; }

        public virtual bool Contains(Point p)
        {
            return false;
        }

        public bool Contains(Point[] points)
        {
            foreach (var p in points)
                if (Contains(p)) return true;
            return false;
        }

        public virtual double GetArea()
        {
            return 0;
        }

    }

    class Square : Figure
    {
        public int Size { get; set; }
        public override bool Contains(Point p)
        {
            return
                Math.Abs(p.X - Location.X) < Size / 2 &&
                Math.Abs(p.Y - Location.Y) < Size / 2;
        }
        public override double GetArea()
        {
            return Math.Pow(Size, 2);
        }
    }

    class Circle : Figure
    {
        public int Radius { get; set; }
        public override bool Contains(Point p)
        {
            return
                Math.Sqrt(Math.Pow(p.X - Location.X, 2) + Math.Pow(p.Y - Location.Y, 2)) < Radius;
        }
        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    public class Program
    {
        static void MainX(string[] args)
        {
            var scene = new List<Figure>
            {
                new Square { Location=new Point(0,0), Size=2 },
                new Circle { Location=new Point(1,1), Radius=3 },
                new Figure { Location=new Point(0,1) }
            };

            var point = new Point(1, 0);
            foreach (var e in scene)
                Console.WriteLine(e.Contains(point));

            foreach (var e in scene)
                Console.WriteLine(e.GetArea());
        }
    }
}
