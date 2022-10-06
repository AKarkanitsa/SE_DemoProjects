using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IClonableImplementation_3
{
    class Person : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Work { get; set; }
        public Person(string name, int age, Company company)
        {
            Name = name;
            Age = age;
            Work = company;
        }
        //глубокое клонирование
        public object Clone() => new Person(Name, Age, new Company(Work.Name));
    }
    class Company
    {
        public string Name { get; set; }
        public Company(string name) => Name = name;
    }
    public class Program
    {
        static void MainX(string[] args)
        {
            var tom = new Person("Tom", 23, new Company("Microsoft"));
            var bob = (Person)tom.Clone();
            bob.Work.Name = "Google";
            Console.WriteLine(tom.Work.Name); // Выведет Microsoft
            Console.WriteLine(bob.Work.Name); // Выведет Google
        }
    }
}


