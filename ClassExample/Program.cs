using System;

namespace ClassExample
{
    public class Shar
    {
        private double radius;  // >0

        public double GetRadius()
        {
            return radius;
        }

        public void SetRadius(double r)  
        {
            if (r > 0)  radius = r;
        }
        
    }


    class Program
    {
        static void Main(string[] args)
        {
            Shar shar = new Shar();
            shar.SetRadius(100);
            
        }
    }
}
