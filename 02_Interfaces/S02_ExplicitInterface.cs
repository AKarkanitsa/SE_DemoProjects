using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterface
{
    interface IInterface1
    {
        void Method();
    }

    interface IInterface2
    {
        void Method();
    }

    public class Class : IInterface1, IInterface2
    {

        void IInterface1.Method()
        {
            Console.WriteLine("Interface 1");
        }

        void IInterface2.Method()
        {
            Console.WriteLine("Interface 2");
        }
    }

    class Program
    {
        public static void MainX()
        {
            var obj = new Class();
            //obj.Method(); // такого метода в классе нет!
            (obj as IInterface1).Method();
            (obj as IInterface2).Method();


        }
    }
}
