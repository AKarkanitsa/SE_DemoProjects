using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableImplementation_01
{
    public class Program
    {
        class Person : IComparable
        {
            public string Name { get; }
            public int Age { get; set; }
            public Person(string name, int age)
            {
                Name = name; Age = age;
            }
            public int CompareTo(object? o) //сравнение объектов типа Person по имени
            {
                if (o is Person)
                      return (o as Person).Name.CompareTo(Name);
                //или более короткая запись
                // if(o is Person person)
                //      return Name.CompareTo(person.Name);
               
                else throw new ArgumentException("Некорректное значение параметра");
            }
        }
        static void MainX(string[] args)
        {
            int[] numbers = new int[] { 97, 45, 32, 65, 83, 23, 15 };
            //метод Sort по умолчанию работает только для базовых простых типов, как int или string
            //Для сотировки сложных объектов пользовательских типов метод Sort работать не будет
            Array.Sort(numbers); 
            foreach (int n in numbers)  Console.WriteLine(n);
            // 15 23 32 45 65 83 97


            Person[] persons = new Person[]
            {
                new Person("Bob", 37),
                new Person("Alisa", 41),
                new Person("Bob", 41)
            };
            //Сортировка массива объектов типа Person
            Array.Sort(persons);
            foreach (Person person in persons)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
