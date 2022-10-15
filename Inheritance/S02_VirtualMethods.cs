using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
{
    class BaseClass
    {
        public virtual void Print()
        {
            Console.WriteLine("Base class");
        }
    }

    class DerivedClass : BaseClass
    {
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Derived class");
        }
    }

    public class Program
    {
        static void MainX(string[] args)
        {
            var baseObj = new BaseClass();
            baseObj.Print();

            var derivedObj = new DerivedClass();
            derivedObj.Print();

           var derivedAsBase = (BaseClass)derivedObj;
           derivedAsBase.Print();
        }
    }
}

