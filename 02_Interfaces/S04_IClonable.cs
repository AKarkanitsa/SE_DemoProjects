using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IClonableImplementation
{
    class Person : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public object Clone()
        {
            return new Person(Name, Age);
            //или так
            //return MemberwiseClone(); - Этот метод реализует неглубокое (поверхностное клонирование)
        }
    }

    public class Program
    {
        static void MainX(string[] args)
        {
            var tom = new Person("Tom", 23);
            var bob = (Person)tom.Clone();
            bob.Name = "Bob";
            Console.WriteLine(tom.Name); // Tom
        }
    }
}
