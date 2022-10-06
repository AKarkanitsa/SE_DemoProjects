using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comarator
{
    //В случае, если необходимо выполнять сравнение объектов по разным параметрам,
    //например, в одном случае - по длине имени, в другом- по возрасту,
    //то удобнее реализовать компараторы, используя интерфейс IComparer<T>
    //В этом случае не придется выполнять приведение типов (от object к Person)
    class ComparerByName : IComparer<Person>  //по длине имени
    {
        public int Compare(Person? p1, Person? p2)
        {
            if (p1 is null || p2 is null)
                throw new ArgumentException("Некорректное значение параметра");
            return p1.Name.Length - p2.Name.Length;
        }
    }

    class ComparerByAge : IComparer<Person> //по возрасту
    {
        public int Compare(Person? p1, Person? p2)
        {
            if (p1 is null || p2 is null)
                throw new ArgumentException("Некорректное значение параметра");
            return p1.Age.CompareTo(p2.Age);
        }
    }

    class Person
    {
        public string Name { get; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name; Age = age;
        }
    }

    public class Program
    {
        static void MainX(string[] args)
        {
            Person[] persons = new Person[]
            {
                new Person("Jane", 37),
                new Person("Alisa", 41),
                new Person("Tom", 40)
            };
            //Сортировка массива объектов типа Person по длине имени
            Array.Sort(persons, new ComparerByName());
            foreach (Person person in persons)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
            Console.WriteLine("===================================");

            //Сортировка массива объектов типа Person по возрасту
            Array.Sort(persons, new ComparerByAge());
            foreach (Person person in persons)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

        }
    }
}
